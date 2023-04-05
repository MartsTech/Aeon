using BuildingBlocks.MassTransit.Contracts;
using MassTransit;

namespace Catalog.Api.Comments.DeleteComment;

public class DeleteCommentConsumer : IConsumer<CommentDeleted>
{
    private readonly ILogger<DeleteCommentConsumer> _logger;

    public DeleteCommentConsumer(ILogger<DeleteCommentConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<CommentDeleted> context)
    {
        _logger.LogInformation("Comment deleted with ID: {MessageId}", context.Message.Id);
        return Task.CompletedTask;
    }
}