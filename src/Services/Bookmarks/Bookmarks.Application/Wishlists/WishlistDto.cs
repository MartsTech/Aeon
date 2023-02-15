using Bookmarks.Domain.Wishlists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookmarks.Application.Bookmarks;
using Bookmarks.Domain.Bookmarks;

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
