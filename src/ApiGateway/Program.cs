using BuildingBlocks.Authentication;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

new WebHostBuilder()
    .UseKestrel()
    .UseContentRoot(Directory.GetCurrentDirectory())
    .ConfigureAppConfiguration((hostingContext, config) =>
    {
        config
            .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
            .AddJsonFile("appsettings.json", true, true)
            .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
            .AddJsonFile("ocelot.json")
            .AddEnvironmentVariables();
    })
    .ConfigureServices((context, services) => {
        services.AddOcelot();
        services.AddMvc();
        services.AddSwaggerForOcelot(context.Configuration);
        services.AddAuthentication(context.Configuration);
    })
    .ConfigureLogging((hostingContext, logging) =>
    {
        //add your logging
    })
    .UseIISIntegration()
    .Configure(app =>
    {
        app.UseSwaggerForOcelotUI();
        app.UseOcelot().Wait();
    })
    .Build()
    .Run();