﻿using System.Reflection;
using BuildingBlocks.Core.Event;
using BuildingBlocks.Web;
using Humanizer;
using MassTransit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BuildingBlocks.MassTransit;

public static class Extensions
{
    private static bool? _isRunningInContainer;

    private static bool IsRunningInContainer => _isRunningInContainer ??=
        bool.TryParse(Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER"), out var inContainer) &&
        inContainer;

    public static IServiceCollection AddCustomMassTransit(this IServiceCollection services, Assembly assembly,
        IWebHostEnvironment env)
    {
        services.AddOptions<RabbitMqOptions>()
            .BindConfiguration(nameof(RabbitMqOptions))
            .ValidateDataAnnotations();

        if (env.IsEnvironment("test"))
        {
            services.AddMassTransitTestHarness(configure =>
            {
                SetupMasstransitConfigurations(services, assembly, configure);
            });
        }
        else
        {
            services.AddMassTransit(configure =>
            {
                SetupMasstransitConfigurations(services, assembly, configure);
            });
        }

        return services;
    }

    private static void SetupMasstransitConfigurations(IServiceCollection services, Assembly assembly,
        IBusRegistrationConfigurator configure)
    {
        configure.AddConsumers(assembly);

        configure.UsingRabbitMq((context, configurator) =>
        {
            var rabbitMqOptions = services.GetOptions<RabbitMqOptions>(nameof(RabbitMqOptions));

            var host = IsRunningInContainer ? "rabbitmq" : rabbitMqOptions.HostName;

            configurator.Host(host, rabbitMqOptions?.Port ?? 5672, "/", h =>
            {
                h.Username(rabbitMqOptions?.UserName);
                h.Password(rabbitMqOptions?.Password);
            });

            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => x.IsAssignableTo(typeof(IIntegrationEvent))
                            && !x.IsInterface
                            && !x.IsAbstract
                            && !x.IsGenericType);

            foreach (var type in types)
            {
                var consumers = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                    .Where(x => x.IsAssignableTo(typeof(IConsumer<>).MakeGenericType(type))).ToList();

                if (consumers.Any())
                    configurator.ReceiveEndpoint(
                        string.IsNullOrEmpty(rabbitMqOptions.ExchangeName)
                            ? type.Name.Underscore()
                            : $"{rabbitMqOptions.ExchangeName}_{type.Name.Underscore()}", e =>
                        {
                            e.UseConsumeFilter(typeof(ConsumeFilter<>), context); //generic filter

                            foreach (var consumer in consumers)
                            {
                                configurator.ConfigureEndpoints(context, x => x.Exclude(consumer));
                                var methodInfo = typeof(DependencyInjectionReceiveEndpointExtensions)
                                    .GetMethods()
                                    .Where(x => x.GetParameters()
                                        .Any(p => p.ParameterType == typeof(IServiceProvider)))
                                    .FirstOrDefault(x => x.Name == "Consumer" && x.IsGenericMethod);

                                var generic = methodInfo?.MakeGenericMethod(consumer);
                                generic?.Invoke(e, new object[] {e, context, null});
                            }
                        });
            }
        });
    }
}