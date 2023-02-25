using BuildingBlocks.Core;
using BuildingBlocks.EFCore;
using ShoppingCart.Domain;
using ShoppingCart.Domain.ShoppingCarts;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace ShoppingCart.Application.ShoppingCarts.AddShoppingCart;

public sealed class CreateShoppingCartCommand
{
    public class Command : IRequest<Result<CategoryDto>>
    {
        public Command(CreateShoppinCartInput input)
        {
            Input = input;
        }

        public CreateShoppinCartInput Input { get; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x => x.Input).SetValidator(new CreateShoppingCartInputValidator());
        }
    }

    public class Handler : IRequestHandler<Command, Result<CategoryDto>>
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

            ShoppingCart shoppingCart = _entityFactory.NewShoppingCart(request.Input.Name);

            bool success = await CreateCategory(shoppingCart, cancellationToken)
                .ConfigureAwait(false);

            return success
                ? Result<ShoppingCartDto>.Success(new ShoppingCartDto(shoppingCart))
                : Result<ShoppingCartDto>.Failure("Failed to create a shopping cart");
        }

        private async Task<bool> CreateShoppingCart(ShoppingCart shoppingCart, CancellationToken cancellationToken)
        {
            await _shoppingCartRepository
                .AddShoppingCart(shoppingCart)
                .ConfigureAwait(false);

            var changes = await _unitOfWork
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            return changes > 0;
        }
    }

}