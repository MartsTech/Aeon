using BuildingBlocks.Core;
using BuildingBlocks.EFCore;
using ShoppingCart.Domain;
using ShoppingCart.Domain.ShoppingCarts;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace ShoppngCart.Application.ShoppingCarts.UpdateShoppingCartName;

public sealed class UpdateShoppingCartCommand
{
    public class Command : IRequest<Result<ShoppingCartDto>>
    {
        public Command(UpdateShoppingCartInput input)
        {
            Input = input;
        }

        public UpdateShoppingCartInput Input { get; }
    }

    private class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x => x.Input).SetValidator(new UpdateShoppingCartInputValidator());
        }
    }

    public class Handler : IRequestHandler<Command, Result<ShoppingCartDto>>
    {
        private readonly IEntityFactory _entityFactory;
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IEntityFactory entityFactory, IShoppingCartRepository shoppingCartRepository, IUnitOfWork unitOfWork)
        {
            _entityFactory = entityFactory;
            _shoppingCartRepository = shoppingCartRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<ShoppingCartDto>> Handle(Command request, CancellationToken cancellationToken)
        {
            CommandValidator validator = new CommandValidator();
            ValidationResult validation = await validator.ValidateAsync(request, cancellationToken);
            if (!validation.IsValid)
            {
                return Result<ShoppingCartDto>.Failure($"{string.Join('\n', validation.Errors)}");
            }

            ShoppingCart? shoppingCart = await _shoppingCartRepository.GetShoppingCartById(request.Input.Id);
            if (shoppingCart == null)
            {
                return Result<ShoppingCartDto>.Failure($"Shopping cart with ID {request.Input.Id} not found");
            }

            bool success = await UpdateShoppingCart(request.Input.Id, request.Input.NewName, cancellationToken)
                .ConfigureAwait(false);

            return success
                ? Result<ShoppingCartDto>.Success(new ShoppingCartDto(shoppingCart))
                : Result<ShoppingCartDto>.Failure($"Failed to update shopping cart {request.Input.Id}");
        }

        private async Task<bool> UpdateShoppingCart(Guid id, string newName, CancellationToken cancellationToken)
        {
            await _shoppingCartRepository
                .UpdateCategoryName(id, newName)
                .ConfigureAwait(false);

            var changes = await _unitOfWork
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            return changes > 0;
        }
    }

}