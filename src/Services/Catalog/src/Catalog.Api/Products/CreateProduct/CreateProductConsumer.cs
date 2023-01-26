using BuildingBlocks.MassTransit.Contracts;
using MassTransit;

namespace Catalog.Api.Products.CreateProduct;

public class CreateProductConsumer : IConsumer<ProductCreated>
{
    private readonly ILogger<CreateProductConsumer> _logger;

    public CreateProductConsumer(ILogger<CreateProductConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<ProductCreated> context)
    {
        _logger.LogInformation("Product created with ID: {MessageId}", context.Message.Id);
        return Task.CompletedTask;
    }
}