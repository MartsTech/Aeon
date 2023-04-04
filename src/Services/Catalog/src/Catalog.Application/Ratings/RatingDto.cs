using Catalog.Domain.Ratings;

namespace Catalog.Application.Ratings;

public sealed record RatingDto : IRating
{
    public RatingDto(IRating rating)
    {
        Id = rating.Id;
        UserId = rating.UserId;
        ProductId = rating.ProductId;
        Value = rating.Value;
    }

    public Guid Id { get; }
    public Guid UserId { get; }
    public Guid ProductId { get; }
    public int Value { get; }
}