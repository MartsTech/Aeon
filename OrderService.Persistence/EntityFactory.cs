using OrderService.Domain;
using OrderService.Domain.Orders;
using OrderService.Domain.OrderLists;


namespace OrderService.Persistence;

public class EntityFactory : IEntityFactory
{

    public Order NewOrder(Guid id, Guid productId, int productQuantity, DateOnly dateAdded, Guid userId, Guid listId)
    {
        return new Order(Guid.NewGuid(), id, productId,productQuantity,dateAdded, userId,listId);
    }

    public OrderList NewOrderList(Guid id, Guid userId, DateOnly dateCreated)
    {
        return new OrderList(Guid.NewGuid(), userId, dateCreated);
    }

    
}