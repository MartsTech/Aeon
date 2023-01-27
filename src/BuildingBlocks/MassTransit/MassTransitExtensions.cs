using System.Reflection;
using BuildingBlocks.Web;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.MassTransit;

public static class MassTransitExtensions
{
    public static IServiceCollection AddCustomMassTransit(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMassTransit(x =>
        {
            x.SetKebabCaseEndpointNameFormatter();

            x.SetInMemorySagaRepositoryProvider();

            var entryAssembly = Assembly.GetEntryAssembly();

            x.AddConsumers(entryAssembly);
            x.AddSagaStateMachines(entryAssembly);
            x.AddSagas(entryAssembly);
            x.AddActivities(entryAssembly);
            
            // var rabbitMqOptions = configuration.GetOptions<RabbitMqOptions>("RabbitMqOptions");
            
            // x.UsingRabbitMq((ctx, cfg) =>
            // {
            //     cfg.Host(new Uri($"amqps://{rabbitMqOptions.HostName}:{rabbitMqOptions.Port}"), h =>
            //     {
            //             h.Username(rabbitMqOptions?.UserName);
            //             h.Password(rabbitMqOptions?.Password);
            //         });
            //     
            //         cfg.ConfigureEndpoints(ctx);
            //     });
            
            x.UsingInMemory();
        });
        
        services.AddOptions<MassTransitHostOptions>()
            .Configure(options =>
            {
                options.WaitUntilStarted = true;
                options.StartTimeout = TimeSpan.FromSeconds(10);
                options.StopTimeout = TimeSpan.FromSeconds(30);
            });

        return services;
    }
}