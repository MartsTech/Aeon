using ShoppingCart.Domain.Products;

namespace ShoppingCart.Domain.Products
{
    public class Product : IProduct
    {
        public Product(Guid id, string title, string? description, decimal price, decimal? discount, Guid categoryId, string? image, int quantity)
        {
            Id = id;
            
            Quantity = quantity;
        }

        public Guid Id { get; }
        public int Quantity { get; set; }
    }
}
