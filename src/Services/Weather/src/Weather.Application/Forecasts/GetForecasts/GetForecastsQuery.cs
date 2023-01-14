using BuildingBlocks.Core;
using MediatR;
using Weather.Domain.Forecasts;

namespace Weather.Application.Forecasts.GetForecasts;

public sealed class GetForecastsQuery
{
    public class Query : IRequest<Result<IList<ForecastDto>>>
    {
    }

    public class Handler : IRequestHandler<Query, Result<IList<ForecastDto>>>
    {
        private readonly IForecastRepository _forecastRepository;

        public Handler(IForecastRepository forecastRepository)
        {
            _forecastRepository = forecastRepository;
        }

        public async Task<Result<IList<ForecastDto>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await GetForecasts()
                .ConfigureAwait(false);
            
            return Result<IList<ForecastDto>>.Success(result);
        }
        
        private async Task<IList<ForecastDto>> GetForecasts()
        {
            var forecasts = await _forecastRepository
                .GetForecasts()
                .ConfigureAwait(false);
            
            return new List<ForecastDto>(forecasts.Select(forecast => new ForecastDto(forecast)));
        }
    }
}