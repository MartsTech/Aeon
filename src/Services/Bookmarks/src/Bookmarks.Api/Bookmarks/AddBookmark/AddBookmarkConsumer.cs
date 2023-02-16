using BuildingBlocks.MassTransit.Contracts;
using MassTransit;

namespace Bookmarks.Api.Bookmarks.AddBookmark;

public class AddBookmarkConsumer : IConsumer<BookmarkCreated>
{
    private readonly ILogger<AddBookmarkConsumer> _logger;

    public AddBookmarkConsumer(ILogger<AddBookmarkConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<BookmarkCreated> context)
    {
        _logger.LogInformation("Bookmark created with ID: {MessageId}", context.Message.Id);
        return Task.CompletedTask;
    }
}