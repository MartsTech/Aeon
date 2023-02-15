using BuildingBlocks.MassTransit.Contracts;
using MassTransit;

namespace Bookmarks.Api.Bookmarks.UpdateBookmark;

public class UpdateBookmarkConsumer : IConsumer<BookmarkUpdated>
{
    private readonly ILogger<UpdateBookmarkConsumer> _logger;

    public UpdateBookmarkConsumer(ILogger<UpdateBookmarkConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<BookmarkUpdated> context)
    {
        _logger.LogInformation("Bookmark updated with ID: {MessageId}", context.Message.Id);
        return Task.CompletedTask;
    }
}