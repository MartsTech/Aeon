using BuildingBlocks.MassTransit.Contracts;
using MassTransit;

namespace OrderService.Api.Order.DeleteOrder
{

    public class DeleteOrderConsumer : IConsumer<OrderDeleted>
    {
        private readonly ILogger<DeleteOrderConsumer> _logger;

        public DeleteOrderConsumer(ILogger<DeleteOrderConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<OrderDeleted> context)
        {
            _logger.LogInformation("Order deleted with ID: {MessageId}", context.Message.Id);
            return Task.CompletedTask;
        }
    }
}