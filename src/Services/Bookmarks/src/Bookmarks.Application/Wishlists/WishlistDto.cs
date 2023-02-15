using Bookmarks.Application.Bookmarks;
using Bookmarks.Domain.Wishlists;

namespace Bookmarks.Application.Wishlists
{
    public class WishlistDto : IWishlist
    {
        public WishlistDto(Wishlist wishlist)
        {
            Id = wishlist.Id;
            UserId = wishlist.UserId;
            DateCreated = wishlist.DateCreated;
            Bookmarks = wishlist.Bookmarks.Select(b => new BookmarkDto(b)).ToList();
        }

        public Guid Id { get; }
        public Guid UserId { get; }
        public DateOnly DateCreated { get; }
        public IList<BookmarkDto> Bookmarks { get; }
    }
}