using Catalog.Domain.Products;

namespace Cart.Domain.Carts
{
    public class ShoppingCart : IShoppingCart
    {
        public ShoppingCart(Guid id, Guid userId, DateOnly dateCreated)
        {
            Id = id;
            UserId = userId;
            DateCreated = dateCreated;
            Products = new List<Product>();
        }

        public Guid Id { get; }
        public Guid UserId { get; }
        public DateOnly DateCreated { get; }
        public IList<Product> Products { get; }
    }
}

