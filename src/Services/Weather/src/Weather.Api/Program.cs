using BuildingBlocks.Authentication;
using BuildingBlocks.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwagger();
builder.Services.AddAuthentication(builder.Configuration);

var app = builder.Build();

app.UseSwagger(app.Environment);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();