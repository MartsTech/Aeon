using BuildingBlocks.Core;
using BuildingBlocks.EFCore;
using Catalog.Domain;
using Catalog.Domain.Categories;
using Catalog.Domain.Products;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Catalog.Application.Products.CreateProduct;

public sealed class CreateProductCommand
{
    public class Command : IRequest<Result<ProductDto>>
    {
        public Command(CreateProductInput input)
        {
            Input = input;
        }

        public CreateProductInput Input { get; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x => x.Input).SetValidator(new CreateProductInputValidator());
        }
    }

    public class Handler : IRequestHandler<Command, Result<ProductDto>>
    {
        private readonly IEntityFactory _entityFactory;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IEntityFactory entityFactory, IProductRepository productRepository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _entityFactory = entityFactory;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<ProductDto>> Handle(Command request, CancellationToken cancellationToken)
        {
            CommandValidator validator = new CommandValidator();
            ValidationResult validation = await validator.ValidateAsync(request, cancellationToken);
            if (!validation.IsValid)
            {
                return Result<ProductDto>.Failure($"{string.Join('\n', validation.Errors)}");
            }

            Category? category = await _categoryRepository.GetCategoryByName(request.Input.CategoryName).ConfigureAwait(false);
            if (category == null)
            {
                return Result<ProductDto>.Failure($"Category {request.Input.CategoryName} not found");
            }

            Product product = _entityFactory.NewProduct(request.Input.Title, request.Input.Description, request.Input.Price, request.Input.Discount, category.Id, request.Input.Image, request.Input.Quantity);

            bool success = await CreateProduct(product, cancellationToken)
                .ConfigureAwait(false);

            return success
                ? Result<ProductDto>.Success(new ProductDto(product))
                : Result<ProductDto>.Failure("Failed to create a product");
        }

        private async Task<bool> CreateProduct(Product product, CancellationToken cancellationToken)
        {
            await _productRepository
                .AddProduct(product)
                .ConfigureAwait(false);

            var changes = await _unitOfWork
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            return changes > 0;
        }
    }

}