using BuildingBlocks.MassTransit.Contracts;
using MassTransit;

namespace Catalog.Api.Categories.AddCategory;

public class AddCategoryConsumer : IConsumer<CategoryCreated>
{
    private readonly ILogger<AddCategoryConsumer> _logger;

    public AddCategoryConsumer(ILogger<AddCategoryConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<CategoryCreated> context)
    {
        _logger.LogInformation("Category created with ID: {MessageId}", context.Message.Id);
        return Task.CompletedTask;
    }
}