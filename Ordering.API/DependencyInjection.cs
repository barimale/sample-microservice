using BuildingBlocks.API.Exceptions.Handler;
using BuildingBlocks.API.Utilities.Healthcheck;
using Carter;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Ordering.API.Filters;
using Ordering.API.Profiles;
using Ordering.API.Utilities;
using Ordering.API.Validators;

namespace Ordering.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCarter();
        services.AddAutoMapper(typeof(ApiProfile));
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddHealthChecks()
            .AddSqlServer(
                configuration["ConnectionStrings:Database"], 
                healthQuery: "select 1", 
                name: "SQL server", 
                failureStatus: HealthStatus.Unhealthy, 
                tags: new[] { "Feedback", "Database" })
            .AddCheck<StarWarsRemoteHealthCheck>(
                "Remote endpoints Health Check", 
                failureStatus: HealthStatus.Unhealthy,
                tags: new[] { "Feedback", "External" })
            .AddCheck<MemoryHealthCheck>(
            $"Feedback Service Memory Check", 
            failureStatus: HealthStatus.Unhealthy, 
            tags: new[] { "Feedback", "Service" });

        services.AddScoped<CreateOrderRequestValidationFilter>();
        services.AddScoped<CreateOrderRequestValidator>();

        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        app.MapCarter();

        app.UseExceptionHandler(options => { });
        app.UseHealthChecks(HeartbeatUtility.Path,
            new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

        return app;
    }
}
