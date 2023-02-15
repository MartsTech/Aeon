using Bookmarks.Domain.Bookmarks;
using Bookmarks.Domain.Wishlists;
using Microsoft.EntityFrameworkCore;

namespace Bookmarks.Persistence.Bookmarks
{
    public class BookmarkRepository : IBookmarkRepository
    {
        public BookmarkRepository(BookmarksDbContext dbContext, IWishlistRepository wishlistRepository)
        {
            _dbContext = dbContext;
            _wishlistRepository = wishlistRepository;
        }

        private readonly BookmarksDbContext _dbContext;
        private readonly IWishlistRepository _wishlistRepository;

        public async Task<bool> AddBookmark(Bookmark bookmark, Guid listId)
        {
            Wishlist? wishlist = await _wishlistRepository.GetListById(listId).ConfigureAwait(false);

            if (wishlist != null)
            {
                wishlist.Bookmarks.Add(bookmark);
                _dbContext.Update(wishlist);
                return true;
            }

            return false;
        }

        public async Task<Bookmark?> GetBookmarkById(Guid id)
        {
            return await _dbContext.Bookmarks.FirstOrDefaultAsync(b => b.Id == id).ConfigureAwait(false);
        }

        public async Task<bool> UpdateBookmark(Guid id, int newQuantity)
        {
            Bookmark? bookmark = await GetBookmarkById(id).ConfigureAwait(false);

            if (bookmark != null)
            {
                bookmark.ProductQuantity = newQuantity;
                _dbContext.Bookmarks.Update(bookmark);
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteBookmark(Guid id)
        {
            Bookmark? bookmark = await GetBookmarkById(id).ConfigureAwait(false);

            if (bookmark != null)
            {
                _dbContext.Bookmarks.Remove(bookmark);
                return true;
            }

            return false;
        }
    }
}