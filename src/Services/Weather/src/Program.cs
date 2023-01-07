using BuildingBlocks.Authentication;
using BuildingBlocks.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwagger();
builder.Services.AddAuthentication(builder.Configuration);

var app = builder.Build();

app.UseSwagger(app.Environment);

// app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();