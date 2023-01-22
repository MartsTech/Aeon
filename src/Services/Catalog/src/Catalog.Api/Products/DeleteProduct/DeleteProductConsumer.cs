using BuildingBlocks.MassTransit.Contracts;
using MassTransit;

namespace Catalog.Api.Products.DeleteProduct;

public class DeleteProductConsumer : IConsumer<ProductDeleted>
{
    private readonly ILogger<DeleteProductConsumer> _logger;

    public DeleteProductConsumer(ILogger<DeleteProductConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<ProductDeleted> context)
    {
        _logger.LogInformation("Product deleted with ID: {MessageId}", context.Message.Id);
        return Task.CompletedTask;
    }
}