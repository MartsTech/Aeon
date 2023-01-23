using BuildingBlocks.Authentication;
using BuildingBlocks.MassTransit;
using BuildingBlocks.Swagger;
using Catalog.Api.Extensions;
using Catalog.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCustomSwagger();
builder.Services.AddCustomAuthentication(builder.Configuration);
builder.Services.AddCustomMassTransit(builder.Configuration);
builder.Services.AddCustomApplication();
builder.Services.AddCustomDomain(builder.Configuration);
builder.Services.AddCustomPersistence();

var app = builder.Build();

app.UseCustomSwagger();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();

var services = scope.ServiceProvider;

try
{
    var context = services.GetRequiredService<CatalogDbContext>();
    await context.Database.MigrateAsync();
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred during migration");
}

await app.RunAsync();
