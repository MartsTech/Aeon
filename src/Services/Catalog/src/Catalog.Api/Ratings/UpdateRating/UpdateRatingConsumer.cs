using BuildingBlocks.MassTransit.Contracts;
using MassTransit;

namespace Catalog.Api.Ratings.UpdateRating;

public class UpdateRatingConsumer : IConsumer<RatingUpdated>
{
    private readonly ILogger<UpdateRatingConsumer> _logger;

    public UpdateRatingConsumer(ILogger<UpdateRatingConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<RatingUpdated> context)
    {
        _logger.LogInformation("Rating updated with ID: {MessageId}", context.Message.Id);
        return Task.CompletedTask;
    }
}