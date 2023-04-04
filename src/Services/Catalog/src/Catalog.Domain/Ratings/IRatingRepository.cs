namespace Catalog.Domain.Ratings;

public interface IRatingRepository
{
    Task<List<Rating>> GetRatingsOfProduct(Guid productId);
    Task<List<Rating>> GetRatingsByUser(Guid userId);
    Task<Rating?> GetRatingById(Guid id);
    Task<bool> AddRating(Rating rating);
    Task<bool> UpdateRating(Guid id, int value);
    Task<bool> DeleteRating(Guid id);

}