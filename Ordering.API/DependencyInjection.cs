using BuildingBlocks.Exceptions.Handler;
using Carter;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Ordering.API.Filters;
using Ordering.API.Validators;

namespace Ordering.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCarter();

        //services.AddHttpLogging();


        services.AddExceptionHandler<CustomExceptionHandler>();
        services.AddHealthChecks();
        //.AddSqlServer(configuration.GetConnectionString("Database")!);

        services.AddScoped<CreateOrderRequestValidationFilter>();
        services.AddScoped<CreateOrderRequestValidator>();

        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        app.MapCarter();

        app.UseExceptionHandler(options => { });
        app.UseHealthChecks("/health",
            new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

        return app;
    }
}
