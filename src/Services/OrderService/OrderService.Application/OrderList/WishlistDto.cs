using OrderService.Application.Orders;
using OrderService.Domain.OrderList;

namespace OrderService.Application.Wishlists
{
    public class OrderListDto : IOrderList
    {
        public OrderListDto(OrderList orderList)
        {
            Id = orderList.Id;
            UserId = orderList.UserId;
            DateCreated = orderList.DateCreated;
            Orders = orderList.Orders.Select(b => new OrderDto(b)).ToList();
        }

        public Guid Id { get; }
        public Guid UserId { get; }
        public DateOnly DateCreated { get; }
        public IList<OrderDto> Orders { get; }
    }
}