using Catalog.Domain.Products;
using Catalog.Application.Products;

using Cart.Domain.Carts;

namespace Cart.Application.Carts
{
    public class ShoppingCartDto : IShoppingCart
    {
        public ShoppingCartDto(ShoppingCart shoppingCart)
        {
            Id = shoppingCart.Id;
            UserId = shoppingCart.UserId;
            DateCreated = shoppingCart.DateCreated;
            Products = shoppingCart.Products.Select(p => new ProductDto(p)).ToList();
        }

        public Guid Id { get; }
        public Guid UserId { get; }
        public DateOnly DateCreated { get; }
        public IList<ProductDto> Products { get; }
    }
}