using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.Web;

public static class CustomCorsExtensions
{
    private const string CorsPolicy = "corsPolicy";

    public static IServiceCollection AddCustomCors(this IServiceCollection services)
    {
        services.AddCors(opt =>
        {
            opt.AddPolicy(CorsPolicy, builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });

        return services;
    }

    public static IApplicationBuilder UseCustomCors(this IApplicationBuilder app)
    {
        app.UseCors(CorsPolicy);
        return app;
    }
}