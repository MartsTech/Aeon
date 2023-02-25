using OrderService.Domain.OrderLists;
using Microsoft.EntityFrameworkCore;

namespace Bookmarks.Persistence.Wishlists
{
    public class OrderListRepository : IOrderListRepository
    {
        public OrderListRepository(OrdersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly OrdersDbContext _dbContext;

        public async Task<List<OrderList>> GetAllLists(Guid userId, bool includeOrders)
        {
            return includeOrders
                ? await _dbContext.OrderLists
                    .Where(x => x.UserId == userId)
                    .Include(l => l.Orders)
                    .ToListAsync()
                    .ConfigureAwait(false)
                
                : await _dbContext.OrderLists.ToListAsync().ConfigureAwait(false);
        }

        public async Task<OrderList?> GetListById(Guid userId, Guid id)
        {
            return await _dbContext.OrderLists
                .Where(x => x.UserId == userId)
                .Include(l => l.OrderLists)
                .FirstOrDefaultAsync(l => l.Id == id)
                .ConfigureAwait(false);
        }

        public async Task CreateNewList(OrderList orderList)
        {
            await _dbContext.OrderLists.AddAsync(orderList).ConfigureAwait(false);
        }

        public async Task<bool> DeleteList(Guid id)
        {
            OrderList? orderList = await _dbContext.OrderLists
                .FirstOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);

            if (orderList!= null)
            {
                _dbContext.OrderLists.Remove(orderList);
                return true;
            }

            return false;
        }
    }
}