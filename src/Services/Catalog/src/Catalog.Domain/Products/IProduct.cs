using Catalog.Domain.Comments;
using Catalog.Domain.Ratings;

namespace Catalog.Domain.Products
{
    public interface IProduct
    {
        public Guid Id { get; }
        public string Title { get; }
        public string? Description { get; }
        public decimal Price { get; }
        public decimal? Discount { get; }
        public Guid CategoryId { get; }
        public string? Image { get; }
        public int Quantity { get; }
        public ICollection<Rating> Ratings { get; }
        public ICollection<Comment> Comments { get; }
    }
}
