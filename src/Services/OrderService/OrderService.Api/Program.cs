
using OrderService.Persistence;
using BuildingBlocks.Authentication;
using BuildingBlocks.MassTransit;
using BuildingBlocks.Swagger;
using BuildingBlocks.Web;
using Microsoft.EntityFrameworkCore;
using OrderService.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCustomSwagger();
builder.Services.AddCustomCors();
builder.Services.AddCustomAuthentication(builder.Configuration);
builder.Services.AddCustomMassTransit(builder.Configuration);
builder.Services.AddCustomApplication();
builder.Services.AddCustomDomain(builder.Configuration);
builder.Services.AddCustomPersistence();

var app = builder.Build();

app.UseCustomSwagger();
app.UseCustomCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();

var services = scope.ServiceProvider;

try
{
    var context = services.GetRequiredService<OrdersDbContext>();
    await context.Database.MigrateAsync();
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred during migration");
}

await app.RunAsync();