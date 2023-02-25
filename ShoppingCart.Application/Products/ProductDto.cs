using ShoppingCart.Domain.Products;

namespace ShoppingCart.Application.Products
{
    public sealed record ProductDto : IProduct
    {
        public ProductDto(IProduct product)
        {
            Id = product.Id;
            Title = product.Title;
            Description = product.Description;
            Price = product.Price;
            Discount = product.Discount;
            CategoryId = product.CategoryId;
            Image = product.Image;
            Quantity = product.Quantity;
        }

        public Guid Id { get; }
        public string Title { get; }
        public string? Description { get; }
        public decimal Price { get; }
        public decimal? Discount { get; }
        public Guid CategoryId { get; set; }
        public string? Image { get; }
        public int Quantity { get; }
    }
}
