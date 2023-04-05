using BuildingBlocks.MassTransit.Contracts;
using MassTransit;

namespace Catalog.Api.Ratings.AddRating;

public class AddRatingConsumer : IConsumer<RatingCreated>
{
    private readonly ILogger<AddRatingConsumer> _logger;

    public AddRatingConsumer(ILogger<AddRatingConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<RatingCreated> context)
    {
        _logger.LogInformation("Rating created with ID: {MessageId}", context.Message.Id);
        return Task.CompletedTask;
    }
}