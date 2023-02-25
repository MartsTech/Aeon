using OrderService.Domain.Orders;
using BuildingBlocks.Authentication;
using BuildingBlocks.Core;
using MediatR;

namespace OrderService.Application.Orders.GetOrder;

public sealed class GetOrderByIdQuery
{
    public class Query : IRequest<Result<OrderDto>>
    {
        public Query(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }

    public class Handler : IRequestHandler<Query, Result<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserService _userService;

        public Handler(IOrderRepository orderRepository, IUserService userService)
        {
            _orderRepository = orderRepository;
            _userService = userService;
        }

        public async Task<Result<OrderDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var userId = _userService.GetCurrentUserId();
            
            if (userId == null)
            {
                return Result<OrderDto>.Failure("No user id found");
            }
            
            var result = await GetOrderById(request.Id, new Guid(userId))
                .ConfigureAwait(false);

            return result != null ? Result<OrderDto>.Success(result) : Result<OrderDto>.Failure("Not found");
        }

        private async Task<OrderDto?> GetOrderById(Guid id, Guid userId)
        {
            Order? order = await _orderRepository
                .GetOrderById(id, userId)
                .ConfigureAwait(false);

            return order != null ? new OrderDto(order) : null;
        }
    }
}