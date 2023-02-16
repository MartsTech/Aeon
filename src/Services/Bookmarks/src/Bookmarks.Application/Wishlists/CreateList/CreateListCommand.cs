using Bookmarks.Domain;
using Bookmarks.Domain.Wishlists;
using BuildingBlocks.Authentication;
using BuildingBlocks.Core;
using BuildingBlocks.EFCore;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Bookmarks.Application.Wishlists.CreateList;

public sealed class CreateListCommand
{
    public class Command : IRequest<Result<WishlistDto>>
    {
        public Command(CreateListInput input)
        {
            Input = input;
        }

        public CreateListInput Input { get; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
        }
    }

    public class Handler : IRequestHandler<Command, Result<WishlistDto>>
    {
        private readonly IEntityFactory _entityFactory;
        private readonly IWishlistRepository _wishlistRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public Handler(IEntityFactory entityFactory, IWishlistRepository wishlistRepository, IUnitOfWork unitOfWork, IUserService userService)
        {
            _entityFactory = entityFactory;
            _wishlistRepository = wishlistRepository;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public async Task<Result<WishlistDto>> Handle(Command request, CancellationToken cancellationToken)
        {
            var userId = _userService.GetCurrentUserId();
            
            if (userId == null)
            {
                return Result<WishlistDto>.Failure("User is not authenticated");
            }
            
            CommandValidator validator = new CommandValidator();
            ValidationResult validation = await validator.ValidateAsync(request, cancellationToken);
            
            if (!validation.IsValid)
            {
                return Result<WishlistDto>.Failure($"{string.Join('\n', validation.Errors)}");
            }

            Wishlist list = _entityFactory.NewList(new Guid(userId));

            bool success = await CreateList(list, cancellationToken)
                .ConfigureAwait(false);

            return success
                ? Result<WishlistDto>.Success(new WishlistDto(list))
                : Result<WishlistDto>.Failure("Failed to create a list");
        }

        private async Task<bool> CreateList(Wishlist list, CancellationToken cancellationToken)
        {
            await _wishlistRepository
                .CreateNewList(list)
                .ConfigureAwait(false);

            var changes = await _unitOfWork
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            return changes > 0;
        }
    }
}