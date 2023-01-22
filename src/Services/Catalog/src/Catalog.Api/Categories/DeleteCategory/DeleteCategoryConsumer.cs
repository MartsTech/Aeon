using BuildingBlocks.MassTransit.Contracts;
using MassTransit;

namespace Catalog.Api.Categories.DeleteCategory;

public class DeleteCategoryConsumer : IConsumer<CategoryDeleted>
{
    private readonly ILogger<DeleteCategoryConsumer> _logger;

    public DeleteCategoryConsumer(ILogger<DeleteCategoryConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<CategoryDeleted> context)
    {
        _logger.LogInformation("Category deleted with ID: {MessageId}", context.Message.Id);
        return Task.CompletedTask;
    }
}