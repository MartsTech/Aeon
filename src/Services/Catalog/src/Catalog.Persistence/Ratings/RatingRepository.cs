using Catalog.Domain.Ratings;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Persistence.Ratings;

public class RatingRepository : IRatingRepository
{
    private readonly CatalogDbContext _context;

    public RatingRepository(CatalogDbContext context)
    {
        _context = context;
    }

    public async Task<List<Rating>> GetRatingsOfProduct(Guid productId)
    {
        return await _context.Ratings.Where(e => e.ProductId == productId).ToListAsync().ConfigureAwait(false);
    }

    public async Task<List<Rating>> GetRatingsByUser(Guid userId)
    {
        return await _context.Ratings.Where(e => e.UserId == userId).ToListAsync().ConfigureAwait(false);
    }

    public async Task<Rating?> GetRatingById(Guid id)
    {
        return await _context.Ratings.FirstOrDefaultAsync(e => e.Id == id).ConfigureAwait(false);
    }

    public async Task<bool> AddRating(Rating rating)
    {
        if (_context.Ratings.Any(e => e.UserId == rating.UserId && e.ProductId == rating.ProductId))
        {
            return false;
        }

        await _context.Ratings.AddAsync(rating).ConfigureAwait(false);
        return true;
    }

    public async Task<bool> UpdateRating(Guid id, int value)
    {
        Rating? dbRating = await GetRatingById(id).ConfigureAwait(false);
        if (dbRating == null)
        {
            return false;
        }

        dbRating.Value = value;

        _context.Ratings.Update(dbRating);
        return true;
    }

    public async Task<bool> DeleteRating(Guid id)
    {
        Rating? rating = await GetRatingById(id).ConfigureAwait(false);
        if (rating == null)
        {
            return false;
        }

        _context.Ratings.Remove(rating);

        return true;
    }
}