using BuildingBlocks.Authentication;
using BuildingBlocks.MassTransit;
using BuildingBlocks.Swagger;
using Catalog.Api.Extensions;

namespace Catalog.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
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

            app.Run();
        }
    }
}