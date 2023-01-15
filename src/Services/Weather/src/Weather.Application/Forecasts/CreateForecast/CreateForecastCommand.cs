using BuildingBlocks.Core;
using BuildingBlocks.EFCore;
using FluentValidation;
using MassTransit;
using MediatR;
using Weather.Domain;
using Weather.Domain.Forecasts;

namespace Weather.Application.Forecasts.CreateForecast;

public sealed class CreateForecastCommand
{
    public class Command : IRequest<Result<ForecastDto>>
    {
        public Command(CreateForecastInput input)
        {
            Input = input;
        }

        public CreateForecastInput Input { get; }
    }
    
    public class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x => x.Input).SetValidator(new CreateForecastInputValidator());
        }
    }

    public class Handler : IRequestHandler<Command, Result<ForecastDto>>
    {
        private readonly IEntityFactory _entityFactory;
        private readonly IForecastRepository _forecastRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IEntityFactory entityFactory, IForecastRepository forecastRepository, IUnitOfWork unitOfWork)
        {
            _entityFactory = entityFactory;
            _forecastRepository = forecastRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<ForecastDto>> Handle(Command request, CancellationToken cancellationToken)
        {
           var forecast = _entityFactory.NewForecast(
               request.Input.Date,
               request.Input.TemperatureC,
               request.Input.Summary);
           
           var success = await CreateForecast(forecast, cancellationToken)
               .ConfigureAwait(false);
            
           return success 
               ? Result<ForecastDto>.Success(new ForecastDto(forecast))
               : Result<ForecastDto>.Failure("Failed to create a forecast");
        }
        
        private async Task<bool> CreateForecast(Forecast forecast, CancellationToken cancellationToken)
        {
            await _forecastRepository
                .CreateForecast(forecast)
                .ConfigureAwait(false);
            
            var changes = await _unitOfWork
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);
            
            return changes > 0;
        }
    }

}