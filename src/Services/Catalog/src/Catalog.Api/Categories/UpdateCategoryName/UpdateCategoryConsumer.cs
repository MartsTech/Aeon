using BuildingBlocks.MassTransit.Contracts;
using MassTransit;

namespace Catalog.Api.Categories.UpdateCategoryName;

public class UpdateCategoryConsumer : IConsumer<CategoryUpdated>
{
    private readonly ILogger<UpdateCategoryConsumer> _logger;

    public UpdateCategoryConsumer(ILogger<UpdateCategoryConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<CategoryUpdated> context)
    {
        _logger.LogInformation("Category updated with ID: {MessageId}", context.Message.Id);
        return Task.CompletedTask;
    }
}