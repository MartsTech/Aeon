using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookmarks.Domain.Bookmarks;
using BuildingBlocks.Authentication;
using BuildingBlocks.Core;
using MediatR;

namespace OrderService.Application.GetOrder
{
    public sealed class GetOrderByIdQuery
    {
        public class Query : IRequest<Result<BookmarkDto>>
        {
            public Query(Guid id)
            {
                Id = id;
            }

            public Guid Id { get; }
        }

        public class Handler : IRequestHandler<Query, Result<BookmarkDto>>
        {
            private readonly IOrderRepository _orderRepository;

            public Handler(IOrderRepository bookmarkRepository)
            {
                _orderRepository = orderRepository;
              
            }

            public async Task<Result<OrderDto>> Handle(Query request, CancellationToken cancellationToken)
            {
               
                var result = await GetBookmarkById(request.Id, new Guid(userId))
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
}
