namespace Bookmarks.Domain.Wishlists
{
    public interface IWishlist
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public DateOnly DateCreated { get; }
    }
}