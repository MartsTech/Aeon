using BuildingBlocks.Core;
using BuildingBlocks.EFCore;
using Catalog.Domain;
using Catalog.Domain.Products;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace ShoppingCart.Application.Products.DeleteProduct;

public sealed class DeleteProductCommand
{
    public class Command : IRequest<Result<string>>
    {
        public Command(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }

    private class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }

    public class Handler : IRequestHandler<Command, Result<string>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<string>> Handle(Command request, CancellationToken cancellationToken)
        {
            CommandValidator validator = new CommandValidator();
            ValidationResult validation = await validator.ValidateAsync(request, cancellationToken);
            if (!validation.IsValid)
            {
                return Result<string>.Failure($"{string.Join('\n', validation.Errors)}");
            }

            bool success = await DeleteProduct(request.Id, cancellationToken)
                .ConfigureAwait(false);

            return success
                ? Result<string>.Success($"Deleted product {request.Id}")
                : Result<string>.Failure($"Failed to delete product {request.Id}");
        }

        private async Task<bool> DeleteProduct(Guid id, CancellationToken cancellationToken)
        {
            await _productRepository
                .DeleteProduct(id)
                .ConfigureAwait(false);

            var changes = await _unitOfWork
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            return changes > 0;
        }
    }

}