﻿using Bookmarks.Domain.Wishlists;
using Microsoft.EntityFrameworkCore;

namespace Bookmarks.Persistence.Wishlists
{
    public class WishlistRepository : IWishlistRepository
    {
        public WishlistRepository(BookmarksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly BookmarksDbContext _dbContext;

        public async Task<List<Wishlist>> GetAllLists(Guid userId, bool includeBookmarks)
        {
            return includeBookmarks
                ? await _dbContext.Wishlists
                    .Where(x => x.UserId == userId)
                    .Include(l => l.Bookmarks)
                    .ToListAsync()
                    .ConfigureAwait(false)
                
                : await _dbContext.Wishlists.ToListAsync().ConfigureAwait(false);
        }

        public async Task<Wishlist?> GetListById(Guid userId, Guid id)
        {
            return await _dbContext.Wishlists
                .Where(x => x.UserId == userId)
                .Include(l => l.Bookmarks)
                .FirstOrDefaultAsync(l => l.Id == id)
                .ConfigureAwait(false);
        }

        public async Task CreateNewList(Wishlist wishlist)
        {
            await _dbContext.Wishlists.AddAsync(wishlist).ConfigureAwait(false);
        }

        public async Task<bool> DeleteList(Guid id)
        {
            Wishlist? wishlist = await _dbContext.Wishlists
                .FirstOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);

            if (wishlist != null)
            {
                _dbContext.Wishlists.Remove(wishlist);
                return true;
            }

            return false;
        }
    }
}