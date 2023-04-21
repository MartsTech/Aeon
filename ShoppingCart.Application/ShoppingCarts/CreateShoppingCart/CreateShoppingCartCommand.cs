using ShoppingCart.Domain;
using ShoppingCart.Domain.Wishlists;
using BuildingBlocks.Authentication;
using BuildingBlocks.Core;
using BuildingBlocks.EFCore;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Application.ShoppingCarts.CreateShoppingCart;

public sealed class CreateShoppingCartCommand
{
    public class Command : IRequest<Result<ShoppingCartDto>>
    {
        public Command(CreateShoppingCartInput input)
        {
            Input = input;
        }

        public CreateShoppingCartInput Input { get; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
        }
    }

    public class Handler : IRequestHandler<Command, Result<ShoppingCartDto>>
    {
        private readonly IEntityFactory _entityFactory;
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public Handler(IEntityFactory entityFactory, IShoppingCartRepository shoppingCartRepository, IUnitOfWork unitOfWork, IUserService userService)
        {
            _entityFactory = entityFactory;
            _shoppingCartRepository = shoppingCartRepository;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public async Task<Result<ShoppingCartDto>> Handle(Command request, CancellationToken cancellationToken)
        {
            var userId = _userService.GetCurrentUserId();

            if (userId == null)
            {
                return Result<ShoppingCartDto>.Failure("User is not authenticated");
            }

            CommandValidator validator = new CommandValidator();
            ValidationResult validation = await validator.ValidateAsync(request, cancellationToken);

            if (!validation.IsValid)
            {
                return Result<ShoppingCartDto>.Failure($"{string.Join('\n', validation.Errors)}");
            }

            ShoppingCart list = _entityFactory.NewList(new Guid(userId));

            bool success = await CreateShoppingCart(list, cancellationToken)
                .ConfigureAwait(false);

            return success
                ? Result<ShoppingCartDto>.Success(new ShoppingCartDto(list))
                : Result<ShoppingCartDto>.Failure("Failed to create a shopping cart");
        }

        private async Task<bool> CreateShoppingCart(ShoppingCart shoppingCart, CancellationToken cancellationToken)
        {
            await _shoppingCartRepository
                .CreateNewList(shoppingCart)
                .ConfigureAwait(false);

            var changes = await _unitOfWork
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            return changes > 0;
        }
    }
}

