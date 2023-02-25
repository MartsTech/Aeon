using ShoppingCart.Domain.ShoppingCarts;
using BuildingBlocks.Authentication;
using BuildingBlocks.Core;
using MediatR;

namespace Bookmarks.Application.Wishlists.GetList;

public sealed class GetShoppingCartByIdQuery
{
    public class Query : IRequest<Result<WishlistDto>>
    {
        public Query(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }

    public class Handler : IRequestHandler<Query, Result<ShoppingCartDto>>
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IUserService _userService;

        public Handler(IShoppingCartRepository shoppingCartRepository, IUserService userService)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _userService = userService;
        }

        public async Task<Result<ShoppingCartDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var userId = _userService.GetCurrentUserId();
            
            if (userId == null)
            {
                return Result<ShoppingCartDto>.Failure("No user id found");
            }
            
            var result = await GetShoppingCartById(request.Id, new Guid(userId))
                .ConfigureAwait(false);

            return result != null ? Result<ShoppingCartDto>.Success(result) : Result<ShoppingCartDto>.Failure("Not found");
        }

        private async Task<ShoppingCartDto?> GetListById(Guid id, Guid userId)
        {
            ShoppingCart? shoppingCart = await _shoppingCartRepository
                .GetShoppingCartById(userId, id)
                .ConfigureAwait(false);

            return shoppingCart != null ? new ShoppingCartDto(wishlist) : null;
        }
    }
}