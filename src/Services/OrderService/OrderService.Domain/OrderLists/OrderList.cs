using OrderService.Domain.Orders;

namespace OrderService.Domain.OrderLists
{
    public class OrderList : IOrderList
    {
        public OrderList(Guid id, Guid userId, DateOnly dateCreated)
        {
            Id = id;
            UserId = userId;
            DateCreated = dateCreated;
            Orders = new List<Order>();
        }

        public Guid Id { get; }
        public Guid UserId { get; }
        public DateOnly DateCreated { get; }
        public IList<Order> Orders { get; }
    }
}