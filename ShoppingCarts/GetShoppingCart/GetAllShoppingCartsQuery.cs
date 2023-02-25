using BuildingBlocks.Core;
using ShoppingCart.Domain.ShoppingCarts;
using MediatR;

namespace Catalog.Application.Categories.GetCategories
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

            public Handler(IShoppingCartRepository shoppingCartRepository)
            {
                _shoppingCartRepository = shoppingCartRepository;
            }

            public async Task<Result<IList<ShoppingCartDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await GetAllCategories(request.IncludeProducts)
                    .ConfigureAwait(false);

                return Result<IList<ShoppingCartDto>>.Success(result);
            }

            private async Task<IList<ShoppingCartDto>> GetAllCategories(bool includeProducts)
            {
                List<ShoppingCart> shoppingCarts = await _shoppingCartRepository
                    .GetAllCategories(includeProducts)
                    .ConfigureAwait(false);

                return new List<ShoppingCartDto>(shoppingCarts.Select(ShoppingCart => new ShoppingCartDto(ShoppingCart)));
            }
        }
    }
}