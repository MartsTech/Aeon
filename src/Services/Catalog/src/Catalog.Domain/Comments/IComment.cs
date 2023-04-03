namespace Catalog.Domain.Comments
{
    public interface IComment
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public Guid ProductId { get; }
        public string Content { get; }
        public ICollection<Upvote> Upvotes { get; }
    }
}
