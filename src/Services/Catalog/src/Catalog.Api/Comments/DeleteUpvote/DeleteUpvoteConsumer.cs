using BuildingBlocks.MassTransit.Contracts;
using MassTransit;

namespace Catalog.Api.Comments.DeleteUpvote;

public class DeleteUpvoteConsumer : IConsumer<UpvoteDeleted>
{
    private readonly ILogger<DeleteUpvoteConsumer> _logger;

    public DeleteUpvoteConsumer(ILogger<DeleteUpvoteConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<UpvoteDeleted> context)
    {
        _logger.LogInformation("Upvote deleted with ID: {MessageId}", context.Message.Id);
        return Task.CompletedTask;
    }
}