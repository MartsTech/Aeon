using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OrderService.Domain;
using OrderService.Domain.Orders;

namespace OrderService.Persistence
{
    public class EntityFactory : IEntityFactory
    {
       

        public Order NewOrder(Guid productId, int productQuantity, Guid listId, Guid userId)
        {
            return new Order(new Guid(), productId, productQuantity, DateOnly.FromDateTime(DateTime.Now), userId, listId);
        }

        public Order NewOrderWithExistingId(Guid id, Guid productId, int productQuantity, Guid listId, Guid userId)
        {
            return new Order(id, productId, productQuantity, DateOnly.FromDateTime(DateTime.Now), listId, userId);
        }
    }
}
