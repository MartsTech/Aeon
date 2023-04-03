using Catalog.Domain.Products;

namespace Catalog.Domain.Comments
{
    public class Comment : IComment
    {
        public Comment(Guid id, Guid userId, Guid productId, string content)
        {
            Id = id;
            UserId = userId;
            ProductId = productId;
            Content = content;
            Upvotes = new List<Upvote>();
        }

        public Guid Id { get; }
        public Guid UserId { get; }
        public Guid ProductId { get; }
        public Product Product { get; }
        public string Content { get; set; }
        public ICollection<Upvote> Upvotes { get; }
    }
}
