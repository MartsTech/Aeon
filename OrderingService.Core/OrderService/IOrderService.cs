using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aeon.Core.Entities;


namespace OrderingService.Core.OrderService
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();
        Order CreateOrder(Order order);
        Order DeleteOrder(int id);
        Order UpdateOrder(int id, Order orderUpdate);
        Order FindOrderById(int id);
        Order FindOrderByIdIncludeProducts(int id);
        Order UpdateOrderAndEmail(int id, Order order);
    }
}
