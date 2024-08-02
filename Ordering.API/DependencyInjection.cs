using BuildingBlocks.Exceptions.Handler;
using Carter;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Ordering.API.Filters;
using Ordering.API.Validators;
using Ordering.Application.Profiles;

namespace Ordering.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCarter();

        services.AddAutoMapper(typeof(ApiProfile));

        services.AddExceptionHandler<CustomExceptionHandler>();
        services.AddHealthChecks();

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
