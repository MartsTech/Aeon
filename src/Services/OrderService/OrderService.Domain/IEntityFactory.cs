using OrderService.Domain.Orders;
using OrderService.Domain.OrderLists;

namespace OrderService.Domain
{
    public interface IEntityFactory
    {
        OrderList NewList(Guid userId);

        Order NewOrder(Guid productId, int productQuantity, Guid listId, Guid userId);

    }
}
