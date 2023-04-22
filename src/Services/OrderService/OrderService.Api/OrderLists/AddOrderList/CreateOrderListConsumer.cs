using BuildingBlocks.MassTransit.Contracts;
using MassTransit;

namespace OrderService.Api.OrderLists.CreateOrderList
{

    public class CreateOrderListConsumer : IConsumer<OrderListCreated>
    {
        private readonly ILogger<CreateOrderListConsumer> _logger;

        public CreateOrderListConsumer(ILogger<CreateOrderListConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<OrderListCreated> context)
        {
            _logger.LogInformation("Order list created with ID: {MessageId}", context.Message.Id);
            return Task.CompletedTask;
        }
    }
}
