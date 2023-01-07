﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BuildingBlocks.Swagger;

public static class SwaggerExtensions
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
    
    public static IApplicationBuilder UseSwagger(this IApplicationBuilder app, IWebHostEnvironment? environment)
    {
        if (environment == null || !environment.IsDevelopment())
        {
            return app;
        }
        
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }
}