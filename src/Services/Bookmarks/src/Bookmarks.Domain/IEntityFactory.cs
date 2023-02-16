using Bookmarks.Domain.Bookmarks;
using Bookmarks.Domain.Wishlists;

namespace Bookmarks.Domain
{
    public interface IEntityFactory
    {
        Wishlist NewList(Guid userId);

        Wishlist NewListWithExistingId(Guid id, Guid userId);

        Bookmark NewBookmark(Guid productId, int productQuantity, Guid listId, Guid userId);

        Bookmark NewBookmarkWithExistingId(Guid id, Guid productId, int productQuantity, Guid listId, Guid userId);
    }
}