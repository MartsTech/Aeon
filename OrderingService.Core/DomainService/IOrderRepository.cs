using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aeon.Core.Entities;

namespace OrderingService.Core.DomainService
{
    public interface IOrderRepository
    {
        IEnumerable<Order> ReadAllOrders();
        Order CreateOrder(Order order);
        Order DeleteOrder(int id);
        Order UpdateOrder(Order orderUpdate);
        Order FindOrderById(int id);
        Order FindOrderByIdIncludeProducts(int id);
        int GetLastOrderNumber();
    }
}
