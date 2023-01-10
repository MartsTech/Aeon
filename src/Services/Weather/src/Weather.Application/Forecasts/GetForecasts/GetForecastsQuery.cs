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

        public Task<Result<IList<ForecastDto>>> Handle(Query request, CancellationToken cancellationToken)
        {
            return GetForecasts();
        }
        
        private async Task<Result<IList<ForecastDto>>> GetForecasts()
        {
            var forecasts = await _forecastRepository
                .GetForecasts()
                .ConfigureAwait(false);
            
            List<ForecastDto> result = new(forecasts.Count);
            
            result.AddRange(forecasts.Select(forecast => new ForecastDto(forecast)));

            return Result<IList<ForecastDto>>.Success(result);
        }
    }
}