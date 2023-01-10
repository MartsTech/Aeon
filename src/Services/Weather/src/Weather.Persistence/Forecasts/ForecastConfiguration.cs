using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Weather.Persistence.Forecasts;

public sealed class ForecastConfiguration: IEntityTypeConfiguration<Domain.Forecasts.Forecast>
{
    public void Configure(EntityTypeBuilder<Domain.Forecasts.Forecast> builder)
    {
        if (builder == null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        builder.Ignore(e => e.TemperatureF);

        builder.Property(e => e.Date)
            .IsRequired();

        builder.Property(e => e.TemperatureC)
            .IsRequired()
            .HasMaxLength(3);

        builder.Property(e => e.Summary)
            .HasMaxLength(255);
    }
}