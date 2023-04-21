using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShoppingCart.Domain.ShoppingCarts;
using Microsoft.EntityFrameworkCore;

namespace Bookmarks.Persistence.Wishlists
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        public ShoppingCartRepository(ShoppingCartDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly ShoppingCartDbContext _dbContext;

        public async Task<List<ShoppingCart>> GetAllLists(Guid userId, bool includeBookmarks)
        {
            return includeBookmarks
                ? await _dbContext.ShoppingCarts
                    .Where(x => x.UserId == userId)
                    .Include(l => l.Products)
                    .ToListAsync()
                    .ConfigureAwait(false)

                : await _dbContext.Wishlists.ToListAsync().ConfigureAwait(false);
        }

        public async Task<ShoppingCart?> GetListById(Guid userId, Guid id)
        {
            return await _dbContext.ShoppingCart
                .Where(x => x.UserId == userId)
                .Include(l => l.Products)
                .FirstOrDefaultAsync(l => l.Id == id)
                .ConfigureAwait(false);
        }

        public async Task CreateNewList(ShoppingCart shoppingCart)
        {
            await _dbContext.ShoppingCarts.AddAsync(shoppingCart).ConfigureAwait(false);
        }

        public async Task<bool> DeleteList(Guid id)
        {
            ShoppingCart? shoppingCart = await _dbContext.ShoppingCart
                .FirstOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);

            if (shoppingCart != null)
            {
                _dbContext.ShoppingCarts.Remove(shoppingCart);
                return true;
            }

            return false;
        }
    }
}
