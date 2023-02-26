using OrderService.Application.Orders;
using OrderService.Domain.Orders;

namespace OrderService.Application.Orders
{
    public class OrderDto : IOrder
    {
        public OrderDto(IOrder order)
        {
            Id = order.Id;
            ProductId = order.ProductId;
            ProductQuantity = order.ProductQuantity;
            DateAdded = order.DateAdded;
            ListId = order.ListId;
            UserId = order.UserId;
        }

        public Guid Id { get; }
        public Guid ProductId { get; }
        public int ProductQuantity { get; }
        public DateOnly DateAdded { get; }
        public Guid ListId { get; }

        public Guid UserId { get; }
    }
}