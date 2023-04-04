using Catalog.Domain.Products;

namespace Catalog.Domain.Ratings;

public class Rating : IRating
{
    public Rating(Guid id, Guid userId, Guid productId, int value)
    {
        Id = id;
        UserId = userId;
        ProductId = productId;
        Value = value;
    }

    public Guid Id { get; }
    public Guid UserId { get; }
    public Guid ProductId { get; }
    public Product Product { get; }
    public int Value { get; set; }
}