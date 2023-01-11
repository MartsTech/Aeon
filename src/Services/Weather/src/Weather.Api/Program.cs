using BuildingBlocks.Authentication;
using BuildingBlocks.Swagger;
using Weather.Api.Extensions;
using Microsoft.EntityFrameworkCore;
using DbContext = Weather.Persistence.DbContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwagger();
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddCustomDbContext(builder.Configuration);
builder.Services.AddCustomMediatR();

var app = builder.Build();

app.UseSwagger(app.Environment);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();