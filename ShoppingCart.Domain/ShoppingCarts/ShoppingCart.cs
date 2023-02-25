using ShoppingCart.Domain.ShoppingCarts;

namespace ShoppingCart.Domain.ShoppingCarts
{
    public class ShoppingCart : IShoppingCart
    {
        public ShoppingCart(Guid id, Guid userId, DateOnly dateCreated)
        {
            Id = id;
            UserId = userId;
            DateCreated = dateCreated;
            ShoppingCarts = new List<ShoppingCart>();
        }

        public Guid Id { get; }
        public Guid UserId { get; }
        public DateOnly DateCreated { get; }
        public IList<ShoppingCart> ShoppingCarts { get; }
    }
}