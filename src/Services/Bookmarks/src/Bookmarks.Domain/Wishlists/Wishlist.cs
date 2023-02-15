using Bookmarks.Domain.Bookmarks;

namespace Bookmarks.Domain.Wishlists
{
    public class Wishlist : IWishlist
    {
        public Wishlist(Guid id, Guid userId, DateOnly dateCreated)
        {
            Id = id;
            UserId = userId;
            DateCreated = dateCreated;
            Bookmarks = new List<Bookmark>();
        }

        public Guid Id { get; }
        public Guid UserId { get; }
        public DateOnly DateCreated { get; }
        public IList<Bookmark> Bookmarks { get; }
    }
}