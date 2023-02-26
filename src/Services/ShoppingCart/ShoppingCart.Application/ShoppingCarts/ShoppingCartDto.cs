using ShoppingCart.Application.ShoppingCarts;
using Catalog.Domain.Products;

namespace ShoppingCart.Application.ShoppingCarts
{
    public class ShoppingCartDto : IShoppingCart
    {
        public ShoppingCartDto(ShoppingCart shoppingCart)
        {
            Id = shoppingCart.Id;
            UserId = shoppingCart.UserId;
            DateCreated = shoppingCart.DateCreated;
            Product = shoppingCart.ShoppingCarts.Select(p => new ShoppingCartDto(p)).ToList();
        }

        public Guid Id { get; }
        public Guid UserId { get; }
        public DateOnly DateCreated { get; }
        public IList<ShoppingCartDto> Products { get; }
    }
}