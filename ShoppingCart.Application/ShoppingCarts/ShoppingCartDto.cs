using ShoppingCart.Application.ShoppingCarts;
using ShoppingCart.Domain.ShoppingCarts;

namespace ShoppingCart.Application.ShoppingCarts
{
    public class ShoppingCartDto : IShoppingCart
    {
        public ShoppingCartDto(ShoppingCart shoppingCart)
        {
            Id = shoppingCart.Id;
            UserId = shoppingCart.UserId;
            DateCreated = shoppingCart.DateCreated;
            Bookmarks = shoppingCart.ShoppingCarts.Select(b => new ShoppingCartDto(b)).ToList();
        }

        public Guid Id { get; }
        public Guid UserId { get; }
        public DateOnly DateCreated { get; }
        public IList<ShoppingCartDto> Bookmarks { get; }
    }
}