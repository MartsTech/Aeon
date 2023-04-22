using OrderService.Domain.Orders;

namespace OrderService.Domain.OrderLists
{
    public interface IOrderList
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public DateOnly DateCreated { get; }
        
    }
}