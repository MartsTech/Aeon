namespace Catalog.Domain.Ratings;

public interface IRating
{
    public Guid Id { get; }
    public Guid UserId { get; }
    public Guid ProductId { get; }
    public int Value { get; }
}