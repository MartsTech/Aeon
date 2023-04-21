using Bookmarks.Domain.Wishlists;
using BuildingBlocks.Authentication;
using BuildingBlocks.Core;
using MediatR;

namespace OrderService.Application.OrderList.GetList;

public sealed class GetListByIdQuery
{
    public class Query : IRequest<Result<OrderListDto>>
    {
        public Query(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }

    public class Handler : IRequestHandler<Query, Result<OrderListDto>>
    {
        private readonly IOrderListRepository _orderListRepository;
        private readonly IUserService _userService;

        public Handler(IOrderLististRepository orderListRepository, IUserService userService)
        {
            _orderListRepository = orderListRepository;
            _userService = userService;
        }

        public async Task<Result<WishlistDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var userId = _userService.GetCurrentUserId();

            if (userId == null)
            {
                return Result<WishlistDto>.Failure("No user id found");
            }

            var result = await GetListById(request.Id, new Guid(userId))
                .ConfigureAwait(false);

            return result != null ? Result<OrderListDto>.Success(result) : Result<OrderListDto>.Failure("Not found");
        }

        private async Task<OrderListDto?> GetListById(Guid id, Guid userId)
        {
            OrderList? orderList = await _orderListRepository
                .GetListById(userId, id)
                .ConfigureAwait(false);

            return orderList != null ? new OrderListDto(orderList) : null;
        }
    }
}
