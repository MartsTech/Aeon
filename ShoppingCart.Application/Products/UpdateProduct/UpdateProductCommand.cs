﻿using BuildingBlocks.Core;
using BuildingBlocks.EFCore;
using ShoppingCart.Domain;
using ShoppingCart.Domain.Categories;
using ShoppingCart.Domain.Products;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace ShoppingCart.Application.Products.UpdateProduct;

public sealed class UpdateProductCommand
{
    public class Command : IRequest<Result<ProductDto>>
    {
        public Command(UpdateProductInput input)
        {
            Input = input;
        }

        public UpdateProductInput Input { get; }
    }

    private class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x => x.Input).SetValidator(new UpdateProductInputValidator());
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

            Product product = _entityFactory.NewProductWithExistingId(request.Input.ProductId, request.Input.Title, request.Input.Description, request.Input.Price, request.Input.Discount, category.Id, request.Input.Image, request.Input.Quantity);

            bool success = await UpdateProduct(request.Input.ProductId, product, cancellationToken)
                .ConfigureAwait(false);

            return success
                ? Result<ProductDto>.Success(new ProductDto(product))
                : Result<ProductDto>.Failure($"Failed to update product {request.Input.ProductId}");
        }

        private async Task<bool> UpdateProduct(Guid id, Product product, CancellationToken cancellationToken)
        {
            await _productRepository
                .UpdateProduct(id, product)
                .ConfigureAwait(false);

            var changes = await _unitOfWork
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            return changes > 0;
        }
    }

}