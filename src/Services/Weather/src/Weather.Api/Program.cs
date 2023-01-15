using BuildingBlocks.Authentication;
using BuildingBlocks.MassTransit;
using BuildingBlocks.Swagger;
using Weather.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCustomAuthentication(builder.Configuration);
builder.Services.AddCustomMassTransit(builder.Configuration);
builder.Services.AddCustomSwagger();
builder.Services.AddCustomDomain(builder.Configuration);
builder.Services.AddCustomApplication();
builder.Services.AddCustomPersistence();

var app = builder.Build();

app.UseCustomSwagger();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();