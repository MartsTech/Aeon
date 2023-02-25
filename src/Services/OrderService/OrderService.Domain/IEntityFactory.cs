using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain
{
    public interface IEntityFactory
    {

        OrderList NewList(Guid userId);

        OrderList NewListWithExistingId(Guid id, Guid userId);
        Order NewOrder(Guid productId, int productQuantity, Guid listId, Guid userId);

        Order NewOrderWithExistingId(Guid id, Guid productId, int productQuantity, Guid listId, Guid userId);
    }
}
