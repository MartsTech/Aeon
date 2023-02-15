using BuildingBlocks.MassTransit.Contracts;
using MassTransit;

namespace Bookmarks.Api.Wishlists.DeleteList;

public class DeleteWishlistConsumer : IConsumer<WishlistDeleted>
{
    private readonly ILogger<DeleteWishlistConsumer> _logger;

    public DeleteWishlistConsumer(ILogger<DeleteWishlistConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<WishlistDeleted> context)
    {
        _logger.LogInformation("Wishlist deleted with ID: {MessageId}", context.Message.Id);
        return Task.CompletedTask;
    }
}