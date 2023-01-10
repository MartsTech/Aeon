using Microsoft.EntityFrameworkCore;
using Weather.Domain.Forecasts;

namespace Weather.Persistence.Forecasts;

public sealed class ForecastRepository: IForecastRepository
{
    private readonly DbContext _context;
    
    public ForecastRepository(DbContext context)
    {
        _context = context;
    }
    
    public async Task<IList<Domain.Forecasts.Forecast>> GetForecasts()
    {
        var forecasts = await _context
            .Forecasts
            .ToListAsync()
            .ConfigureAwait(false);

        return forecasts;
    }
}