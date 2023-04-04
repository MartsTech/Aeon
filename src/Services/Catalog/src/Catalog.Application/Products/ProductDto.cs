using Catalog.Domain.Products;

namespace Catalog.Application.Products
{
    public sealed record ProductDto
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
            CommentCount = product.Comments.Count;
            AvgRating = product.Ratings.Count == 0 ? null : product.Ratings.Average(e => e.Value);
        }

        public Guid Id { get; }
        public string Title { get; }
        public string? Description { get; }
        public decimal Price { get; }
        public decimal? Discount { get; }
        public Guid CategoryId { get; set; }
        public string? Image { get; }
        public int Quantity { get; }
        public double? AvgRating { get; }
        public int CommentCount { get; }
    }
}
