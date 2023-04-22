using OrderService.Domain.Orders;
using OrderService.Domain.OrderLists;

namespace OrderService.Domain
{
    public interface IEntityFactory
    {        

        Order NewOrder(Guid productId, int productQuantity, Guid listId, Guid userId);
        OrderList NewOrderList(Guid id, Guid userId, DateOnly dateCreated);

    }
}
