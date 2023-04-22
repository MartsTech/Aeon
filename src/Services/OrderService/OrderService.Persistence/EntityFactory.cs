using OrderService.Domain;
using OrderService.Domain.Orders;
using OrderService.Domain.OrderLists;


namespace OrderService.Persistence;

public class EntityFactory : IEntityFactory
{

    public Order NewOrder(Guid productId, int productQuantity, Guid listId, Guid userId)
    {
        return new Order(new Guid(), productId, productQuantity, DateOnly.FromDateTime(DateTime.Now), userId, listId);
    }

    public OrderList NewOrderList(Guid id, Guid userId, DateOnly dateCreated)
    {
        return new OrderList(Guid.NewGuid(), userId, dateCreated);
    }

    
}