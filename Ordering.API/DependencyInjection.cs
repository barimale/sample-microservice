using BuildingBlocks.Behaviors;
using BuildingBlocks.Exceptions.Handler;
using Carter;
using HealthChecks.UI.Client;
using MediatR;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;
using Ordering.API.API.v1._0.order_endpoint.delete_orders.Filter;
using Ordering.API.API.v1._0.order_endpoint.post_orders.Validators;
using Ordering.API.Integration;

namespace Ordering.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCarter();

        //services.AddHttpLogging();


        services.AddExceptionHandler<CustomExceptionHandler>();
        services.AddHealthChecks();
        //.AddSqlServer(configuration.GetConnectionString("Database")!);

        services.AddScoped<CreateOrderRequestIsValidFilter>();
        services.AddScoped<CreateOrderRequestValidator>();

        services.AddHttpClient<IStarWarsService, StarWarsHttpClient>((client, sp) =>
        {
            return new StarWarsHttpClient("https://swapi.dev/api/", client);
        });
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
