namespace Bookmarks.Domain.Bookmarks
{
    public interface IBookmark
    {
        public Guid Id { get; }
        public Guid ProductId { get; }
        public int ProductQuantity { get; }
        public DateOnly DateAdded { get; }
        public Guid ListId { get; }
    }
}