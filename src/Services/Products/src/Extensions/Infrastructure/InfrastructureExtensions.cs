using System.Threading.RateLimiting;
using BuildingBlocks.Authentication;
using BuildingBlocks.Core;
using BuildingBlocks.EFCore;
using BuildingBlocks.Exception;
using BuildingBlocks.HealthCheck;
using BuildingBlocks.IdsGenerator;
using BuildingBlocks.Logging;
using BuildingBlocks.Mapster;
using BuildingBlocks.MassTransit;
using BuildingBlocks.Mongo;
using BuildingBlocks.OpenTelemetry;
using BuildingBlocks.PersistMessageProcessor;
using BuildingBlocks.Swagger;
using BuildingBlocks.Web;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Products.Data;
using Products.Data.Seed;

namespace Products.Extensions.Infrastructure;

public static class InfrastructureExtensions
{
       public static WebApplicationBuilder AddInfrastructure(this WebApplicationBuilder builder)
    {
        var configuration = builder.Configuration;
        var env = builder.Environment;

        builder.Services.AddScoped<ICurrentUserProvider, CurrentUserProvider>();
        builder.Services.AddScoped<IEventMapper, EventMapper>();
        builder.Services.AddScoped<IEventDispatcher, EventDispatcher>();
        builder.Services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });

        builder.Services.AddCustomMediatR();
        builder.Services.AddCustomProblemDetails();

        var appOptions = builder.Services.GetOptions<AppOptions>(nameof(AppOptions));
        Console.WriteLine(appOptions.Name);

        builder.Services.AddRateLimiter(options =>
        {
            options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
                RateLimitPartition.GetFixedWindowLimiter(
                    partitionKey: httpContext.User.Identity?.Name ?? httpContext.Request.Headers.Host.ToString(),
                    factory: partition => new FixedWindowRateLimiterOptions
                    {
                        AutoReplenishment = true, PermitLimit = 10, QueueLimit = 0, Window = TimeSpan.FromMinutes(1)
                    }));
        });

        builder.Services.AddCustomDbContext<ProductDbContext>();
        builder.Services.AddScoped<IDataSeeder, ProductDataSeeder>();
        builder.Services.AddMongoDbContext<ProductReadDbContext>(configuration);
        builder.Services.AddPersistMessageProcessor();

        builder.AddCustomSerilog(env);
        builder.Services.AddAuthentication(builder.Configuration);
        builder.Services.AddSwagger();
        builder.Services.AddCustomVersioning();
        builder.Services.AddValidatorsFromAssembly(typeof(ProductRoot).Assembly);
        builder.Services.AddCustomMapster(typeof(ProductRoot).Assembly);
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddCustomMassTransit(typeof(ProductRoot).Assembly, env);
        builder.Services.AddCustomOpenTelemetry();
        builder.Services.AddCustomHealthCheck();

        builder.Services.AddGrpc(options =>
        {
            options.Interceptors.Add<GrpcExceptionInterceptor>();
        });

        SnowFlakIdGenerator.Configure(1);

        builder.Services.AddEasyCaching(options => { options.UseInMemory(configuration, "mem"); });

        return builder;
    }
}