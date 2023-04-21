using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookmarks.Persistence.Wishlists;
using OrderService.Domain.Orders;

namespace OrderService.Persistence
{
    public class OrderRepository : IOrderRepository
    {


        public OrderRepository(OrdersDbContext dbContext, IOrderListRepository orderLististRepository)
        {
            _dbContext = dbContext;
            _orderListRepository = orderListRepository;
        }

        private readonly OrdersDbContext _dbContext;

        private readonly IOrderListRepository _orderListRepository;


        public async Task<bool> AddOrder(Order order)
        {
            var orderList = await _orderListRepository
                .GetListById(order.UserId, order.ListId)
                .ConfigureAwait(false);

            if (orderList != null)
            {
                orderList.Order.Add(order);
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
            Order? order = await GetOrderById(id, userId).ConfigureAwait(false);

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
                _dbContext.OrderService.Remove(orders);
                return true;
            }

            return false;
        }
    }
}
