using BuildingBlocks.Core;
using ShoppingCart.Domain.ShoppingCarts;
using MediatR;

namespace ShoppingCart.Application.ShoppingCarts.GetShoppingCart
{
    public sealed class GetShoppingCartByIdQuery
    {
        public class Query : IRequest<Result<CategoryDto>>
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

            public Handler(IShoppingCartRepository shoppingCartRepository)
            {
                _shoppingCartRepository = shoppingCartRepository;
            }

            public async Task<Result<ShoppingCartDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await GetShoppingCartById(request.Id)
                    .ConfigureAwait(false);

                return result == null ? Result<ShoppingCartDto>.Failure("Not found") : Result<ShoppingCartDto>.Success(result);
            }

            private async Task<ShoppingCartDto?> GetShoppingCartById(Guid id)
            {
                ShoppingCart? shoppingCart = await _shoppingCartRepository
                    .GetShoppingCartById(id)
                    .ConfigureAwait(false);

                return shoppingCart == null ? null : new ShoppingCartDto(shoppingCart);
            }
        }
    }
}