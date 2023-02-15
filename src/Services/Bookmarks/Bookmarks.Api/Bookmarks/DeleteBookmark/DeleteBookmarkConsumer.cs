using BuildingBlocks.MassTransit.Contracts;
using MassTransit;

namespace Bookmarks.Api.Bookmarks.DeleteBookmark;

public class DeleteBookmarkConsumer : IConsumer<BookmarkDeleted>
{
    private readonly ILogger<DeleteBookmarkConsumer> _logger;

    public DeleteBookmarkConsumer(ILogger<DeleteBookmarkConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<BookmarkDeleted> context)
    {
        _logger.LogInformation("Bookmark deleted with ID: {MessageId}", context.Message.Id);
        return Task.CompletedTask;
    }
}