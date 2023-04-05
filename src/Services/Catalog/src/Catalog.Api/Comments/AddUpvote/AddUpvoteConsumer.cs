using BuildingBlocks.MassTransit.Contracts;
using MassTransit;

namespace Catalog.Api.Comments.AddUpvote;

public class AddUpvoteConsumer : IConsumer<UpvoteCreated>
{
    private readonly ILogger<AddUpvoteConsumer> _logger;

    public AddUpvoteConsumer(ILogger<AddUpvoteConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<UpvoteCreated> context)
    {
        _logger.LogInformation("Upvote created with ID: {MessageId}", context.Message.Id);
        return Task.CompletedTask;
    }
}