using BuildingBlocks.MassTransit.Contracts;
using MassTransit;

namespace Catalog.Api.Comments.UpdateComment
{
    public class UpdateCommentConsumer : IConsumer<CommentUpdated>
    {
        private readonly ILogger<UpdateCommentConsumer> _logger;

        public UpdateCommentConsumer(ILogger<UpdateCommentConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<CommentUpdated> context)
        {
            _logger.LogInformation("Comment updated with ID: {MessageId}", context.Message.Id);
            return Task.CompletedTask;
        }
    }
}
