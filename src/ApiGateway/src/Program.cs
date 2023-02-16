using BuildingBlocks.Web;
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
            .AddJsonFile($"ocelot.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
            .AddEnvironmentVariables();
    })
    .ConfigureServices((context, services) => {
        services.AddCustomCors();
        services.AddOcelot();
        services.AddMvc();
        services.AddSwaggerForOcelot(context.Configuration);
    })
    .ConfigureLogging((hostingContext, logging) =>
    {
        //add your logging
    })
    .UseIISIntegration()
    .Configure(app =>
    {
        app.UseCustomCors();
        app.UseSwaggerForOcelotUI();
        app.UseOcelot().Wait();
    })
    .Build()
    .Run();