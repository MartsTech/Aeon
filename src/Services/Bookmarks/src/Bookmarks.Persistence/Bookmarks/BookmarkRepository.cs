using Bookmarks.Domain.Bookmarks;
using Bookmarks.Domain.Wishlists;
using Bookmarks.Persistence.Wishlists;
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

        public async Task<bool> AddBookmark(Bookmark bookmark)
        {
            var wishlist = await _wishlistRepository
                .GetListById(bookmark.UserId, bookmark.ListId)
                .ConfigureAwait(false);

            if (wishlist != null)
            {
                wishlist.Bookmarks.Add(bookmark);
                _dbContext.Update(wishlist);
                return true;
            }

            return false;
        }

        public async Task<Bookmark?> GetBookmarkById(Guid id, Guid userId)
        {
            return await _dbContext.Bookmarks
                .Where(x => x.UserId == userId)
                .FirstOrDefaultAsync(b => b.Id == id)
                .ConfigureAwait(false);
        }

        public async Task<bool> UpdateBookmark(Guid id, int newQuantity, Guid userId)
        {
            Bookmark? bookmark = await GetBookmarkById(id, userId).ConfigureAwait(false);

            if (bookmark != null)
            {
                bookmark.ProductQuantity = newQuantity;
                _dbContext.Bookmarks.Update(bookmark);
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteBookmark(Guid id, Guid userId)
        {
            Bookmark? bookmark = await GetBookmarkById(id, userId).ConfigureAwait(false);

            if (bookmark != null)
            {
                _dbContext.Bookmarks.Remove(bookmark);
                return true;
            }

            return false;
        }
    }
}