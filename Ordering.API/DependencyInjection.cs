using BuildingBlocks.Behaviors;
using BuildingBlocks.Exceptions.Handler;
using Carter;
using HealthChecks.UI.Client;
using MediatR;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Ordering.API.API.v1._0.order_endpoint.delete_orders.Filter;
using Ordering.API.API.v1._0.order_endpoint.post_orders.Validators;

namespace Ordering.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCarter();

        services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));


        services.AddExceptionHandler<CustomExceptionHandler>();
        services.AddHealthChecks();
        //.AddSqlServer(configuration.GetConnectionString("Database")!);

        services.AddScoped<CreateOrderRequestIsValidFilter>();
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
