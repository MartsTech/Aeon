using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.Web;

public static class CustomCorsExtensions
{
    private const string CorsPolicy = "CorsPolicy";

    public static IServiceCollection AddCustomCors(this IServiceCollection services)
    {
        services.AddCors(opt =>
        {
            opt.AddPolicy(CorsPolicy, builder =>
            {
                builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin();
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
