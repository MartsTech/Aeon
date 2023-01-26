using BuildingBlocks.MassTransit.Contracts;
using MassTransit;

namespace Catalog.Api.Products.UpdateProduct;

public class UpdateProductConsumer : IConsumer<ProductUpdated>
{
    private readonly ILogger<UpdateProductConsumer> _logger;

    public UpdateProductConsumer(ILogger<UpdateProductConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<ProductUpdated> context)
    {
        _logger.LogInformation("Product updated with ID: {MessageId}", context.Message.Id);
        return Task.CompletedTask;
    }
}