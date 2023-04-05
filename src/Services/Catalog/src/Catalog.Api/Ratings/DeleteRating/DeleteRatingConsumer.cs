using BuildingBlocks.MassTransit.Contracts;
using MassTransit;

namespace Catalog.Api.Ratings.DeleteRating;

public class DeleteRatingConsumer : IConsumer<RatingDeleted>
{
    private readonly ILogger<DeleteRatingConsumer> _logger;

    public DeleteRatingConsumer(ILogger<DeleteRatingConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<RatingDeleted> context)
    {
        _logger.LogInformation("Rating deleted with ID: {MessageId}", context.Message.Id);
        return Task.CompletedTask;
    }
}