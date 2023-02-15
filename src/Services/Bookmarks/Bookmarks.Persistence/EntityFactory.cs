using Bookmarks.Domain;
using Bookmarks.Domain.Wishlists;
using Bookmarks.Domain.Bookmarks;

namespace Bookmarks.Persistence
{
    public class EntityFactory : IEntityFactory
    {
        public Wishlist NewList(Guid userId)
        {
            return new Wishlist(new Guid(), userId, DateOnly.FromDateTime(DateTime.Now));
        }

        public Wishlist NewListWithExistingId(Guid id, Guid userId)
        {
            return new Wishlist(id, userId, DateOnly.FromDateTime(DateTime.Now));
        }

        public Bookmark NewBookmark(Guid productId, int productQuantity, Guid listId)
        {
            return new Bookmark(new Guid(), productId, productQuantity, DateOnly.FromDateTime(DateTime.Now), listId);
        }

        public Bookmark NewBookmarkWithExistingId(Guid id, Guid productId, int productQuantity, Guid listId)
        {
            return new Bookmark(id, productId, productQuantity, DateOnly.FromDateTime(DateTime.Now), listId);
        }
    }
}
