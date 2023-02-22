using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Persistence
{
    public class OrderRepository : IOrderRepository
    {
        public OrderRepository(OrderServiceDbContext dbContext, IWishlistRepository wishlistRepository)
        {
            _dbContext = dbContext;
            _wishlistRepository = wishlistRepository;
        }

        private readonly OrderServiceDbContext _dbContext;

        private readonly IWishlistRepository _wishlistRepository;

        public async Task<bool> AddOrder(Order order)
        {
            var wishlist = await _wishlistRepository
                .GetListById(bookmark.UserId, bookmark.ListId)
                .ConfigureAwait(false);

            if (wishlist != null)
            {
                wishlist.Order.Add(order);
                _dbContext.Update(order);
                return true;
            }

            return false;
        }

        public async Task<Order?> GetOrderById(Guid id, Guid userId)
        {
            return await _dbContext.Orders
                .Where(x => x.UserId == userId)
                .FirstOrDefaultAsync(b => b.Id == id)
                .ConfigureAwait(false);
        }

        public async Task<bool> UpdateOrder(Guid id, int newQuantity, Guid userId)
        {
            Order? bookmark = await GetOrderById(id, userId).ConfigureAwait(false);

            if (order != null)
            {
                order.ProductQuantity = newQuantity;
                _dbContext.Orders.Update(order);
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteOrder(Guid id, Guid userId)
        {
            Order? order = await GetOrderById(id, userId).ConfigureAwait(false);

            if (order != null)
            {
                _dbContext.Orders.Remove(orders);
                return true;
            }

            return false;
        }
    }
}
