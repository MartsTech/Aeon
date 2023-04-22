using OrderService.Domain.OrderLists;
using BuildingBlocks.Authentication;
using BuildingBlocks.Core;
using MediatR;

namespace OrderService.Application.OrderLists.GetList
{
    public sealed class GetAllListsQuery
    {
        public class Query : IRequest<Result<IList<OrderListDto>>>
        {
            public Query(bool includeOrders)
            {
                IncludeOrders = includeOrders;
            }

            public bool IncludeOrders { get; }
        }

        public class Handler : IRequestHandler<Query, Result<IList<OrderListDto>>>
        {
            private readonly IOrderListRepository _orderListRepository;
            private readonly IUserService _userService;

            public Handler(IOrderListRepository orderListRepository, IUserService userService)
            {
                _orderListRepository = orderListRepository;
                _userService = userService;
            }

            public async Task<Result<IList<OrderListDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var userId = _userService.GetCurrentUserId();

                if (userId == null)
                {
                    return Result<IList<OrderListDto>>.Failure("No user id found");
                }

                var result = await GetAllLists(request.IncludeOrders, new Guid(userId))
                    .ConfigureAwait(false);

                return Result<IList<OrderListDto>>.Success(result);
            }

            private async Task<IList<OrderListDto>> GetAllLists(bool includeOrders, Guid userId)
            {
                List<OrderList> orderLists = await _orderListRepository
                    .GetAllLists(userId, includeOrders)
                    .ConfigureAwait(false);

                return new List<OrderListDto>(orderLists.Select(orderList => new OrderListDto(orderList)));
            }
        }
    }
}
