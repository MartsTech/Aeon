using Microsoft.EntityFrameworkCore;
using Weather.Domain.Forecasts;

namespace Weather.Persistence.Forecasts;

public static class ForecastSeeder
{
    private static readonly string[] Summaries = {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    
    public static void SeedData(ModelBuilder builder)
    {
        if (builder == null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        var factory = new EntityFactory();

        builder.Entity<Forecast>().HasData(Enumerable.Range(1, 5).Select(index =>
            factory.NewForecast(
                DateTime.Now.AddDays(index),
                Random.Shared.Next(-20, 55),
                Summaries[Random.Shared.Next(Summaries.Length)])
            )
        );
    }
}