using OrderService.Domain.OrderList;
using BuildingBlocks.Authentication;
using BuildingBlocks.Core;
using MediatR;

namespace OrderService.Application.OrderList.GetList
{
    public sealed class GetAllListsQuery
    {
        public class Query : IRequest<Result<IList<WishlistDto>>>
        {
            public Query(bool includeOrders)
            {
                IncludeOrders = includeOrders;
            }

            public bool IncludeOrders { get; }
        }

        public class Handler : IRequestHandler<Query, Result<IList<WishlistDto>>>
        {
            private readonly IOrderListRepository _OrderLististRepository;
            private readonly IUserService _userService;

            public Handler(IOrderListRepository orderListRepository, IUserService userService)
            {
                _orderListRepository = orderListlistRepository;
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

                return new List<OrderListDto>(orders.Select(order => new OrderListDto(order)));
            }
        }
    }
}