using Cart.Domain.Carts;
using BuildingBlocks.Authentication;
using BuildingBlocks.Core;
using MediatR;

namespace Cart.Application.Carts.GetShoppingCart
{
    public sealed class GetAllShoppingCartsQuery
    {
        public class Query : IRequest<Result<IList<ShoppingCartDto>>>
        {
            public Query(bool includeProducts)
            {
                IncludeProducts = includeProducts;
            }

            public bool IncludeProducts { get; }
        }

        public class Handler : IRequestHandler<Query, Result<IList<ShoppingCartDto>>>
        {
            private readonly IShoppingCartRepository _shoppingCartRepository;
            private readonly IUserService _userService;

            public Handler(IShoppingCartRepository shoppingCartRepository, IUserService userService)
            {
                _shoppingCartRepository = shoppingCartRepository;
                _userService = userService;
            }

            public async Task<Result<IList<ShoppingCartDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var userId = _userService.GetCurrentUserId();

                if (userId == null)
                {
                    return Result<IList<ShoppingCartDto>>.Failure("No user id found");
                }

                var result = await GetAllShoppingCarts(request.IncludeProducts, new Guid(userId))
                    .ConfigureAwait(false);

                return Result<IList<ShoppingCartDto>>.Success(result);
            }

            private async Task<IList<ShoppingCartDto>> GetAllShoppingCarts(bool includeProducts, Guid userId)
            {
                List<ShoppingCart> shoppingCarts = await _shoppingCartRepository
                    .GetAllLists(userId, includeProducts)
                    .ConfigureAwait(false);

                return new List<ShoppingCartDto>(shoppingCarts.Select(shoppingCart => new ShoppingCartDto(shoppingCart)));
            }
        }
    }
}