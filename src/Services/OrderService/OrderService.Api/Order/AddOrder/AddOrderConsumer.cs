using BuildingBlocks.MassTransit.Contracts;
using MassTransit;

namespace OrderService.Api.Order.AddOrder
{

    public class AddOrderConsumer : IConsumer<OrderCreated>
    {
        private readonly ILogger<AddOrderConsumer> _logger;

        public AddOrderConsumer(ILogger<AddOrderConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<OrderCreated> context)
        {
            _logger.LogInformation("Order created with ID: {MessageId}", context.Message.Id);
            return Task.CompletedTask;
        }
    }
}