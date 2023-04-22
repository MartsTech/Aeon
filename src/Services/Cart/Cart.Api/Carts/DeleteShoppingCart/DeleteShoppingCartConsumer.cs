using BuildingBlocks.MassTransit.Contracts;
using MassTransit;

namespace Cart.Api.ShoppingCarts.DeleteShoppingCart
{


    public class DeleteShoppingCartConsumer : IConsumer<ShoppingCartDeleted>
    {
        private readonly ILogger<DeleteShoppingCartConsumer> _logger;

        public DeleteShoppingCartConsumer(ILogger<DeleteShoppingCartConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<ShoppingCartDeleted> context)
        {
            _logger.LogInformation("Shopping cart deleted with ID: {MessageId}", context.Message.Id);
            return Task.CompletedTask;
        }
    }
}
