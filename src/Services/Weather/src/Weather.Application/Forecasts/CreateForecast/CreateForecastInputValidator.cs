using FluentValidation;

namespace Weather.Application.Forecasts.CreateForecast;

public sealed class CreateForecastInputValidator: AbstractValidator<CreateForecastInput>
{
    public CreateForecastInputValidator()
    {
        RuleFor(x => x.Date).NotEmpty();
        RuleFor(x => x.Summary).NotEmpty();
        RuleFor(x => x.TemperatureC).NotEmpty();
    }
}