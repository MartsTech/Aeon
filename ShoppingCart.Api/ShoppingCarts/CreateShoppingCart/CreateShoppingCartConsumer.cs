using BuildingBlocks.MassTransit.Contracts;
using MassTransit;

namespace ShoppingCart.Api.ShoppingCarts.CreateShoppingCart;

public class AddShoppingCartConsumer : IConsumer<ShoppingCartCreated>
{
    private readonly ILogger<AddShoppingCartConsumer> _logger;

    public AddCategoryConsumer(ILogger<AddShoppingCartConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<ShoppingCartCreated> context)
    {
        _logger.LogInformation("Shopping cart created with ID: {MessageId}", context.Message.Id);
        return Task.CompletedTask;
    }
}
