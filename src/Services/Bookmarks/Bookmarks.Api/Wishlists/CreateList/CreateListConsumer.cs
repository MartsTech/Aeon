using BuildingBlocks.MassTransit.Contracts;
using MassTransit;

namespace Bookmarks.Api.Wishlists.CreateList;

public class CreateListConsumer : IConsumer<WishlistCreated>
{
    private readonly ILogger<CreateListConsumer> _logger;

    public CreateListConsumer(ILogger<CreateListConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<WishlistCreated> context)
    {
        _logger.LogInformation("Wishlist created with ID: {MessageId}", context.Message.Id);
        return Task.CompletedTask;
    }
}