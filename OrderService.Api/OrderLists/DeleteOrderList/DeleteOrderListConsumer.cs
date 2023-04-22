using BuildingBlocks.MassTransit.Contracts;
using MassTransit;

namespace OrderService.Api.OrderLists.DeleteOrderList
{
    public class DeleteOrderListConsumer : IConsumer<OrderListDeleted>
    {
        private readonly ILogger<DeleteOrderListConsumer> _logger;

        public DeleteOrderListConsumer(ILogger<DeleteOrderListConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<DeleteOrderListDeleted> context)
        {
            _logger.LogInformation("Wishlist deleted with ID: {MessageId}", context.Message.Id);
            return Task.CompletedTask;
        }
    }
}
