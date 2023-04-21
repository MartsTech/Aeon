using BuildingBlocks.MassTransit.Contracts;
using MassTransit;

namespace OrderService.Api.OrderLists.AddOrderList

public class AddOrderListConsumer : IConsumer<OrderListCreated>
{
    private readonly ILogger<AddOrderListConsumer> _logger;

    public AddOrderListConsumer(ILogger<CreateOrderListConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<OrderListCreated> context)
    {
        _logger.LogInformation("Order list created with ID: {MessageId}", context.Message.Id);
        return Task.CompletedTask;
    }
}
