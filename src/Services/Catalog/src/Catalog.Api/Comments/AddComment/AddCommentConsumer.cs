using BuildingBlocks.MassTransit.Contracts;
using MassTransit;

namespace Catalog.Api.Comments.AddComment
{
    public class AddCommentConsumer : IConsumer<CommentCreated>
    {
        private readonly ILogger<AddCommentConsumer> _logger;

        public AddCommentConsumer(ILogger<AddCommentConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<CommentCreated> context)
        {
            _logger.LogInformation("Comment created with ID: {MessageId}", context.Message.Id);
            return Task.CompletedTask;
        }
    }
}
