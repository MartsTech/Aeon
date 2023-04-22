using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain.Orders
{
    public interface IOrderRepository
    {
        Task<bool> AddOrder(Order order);
        Task<Order> GetOrderById(Guid id, Guid userId);
        Task<bool> UpdateOrder(Guid id, int newQuantity, Guid userId);
        Task<bool> DeleteOrder(Guid id, Guid userId);
    }
}