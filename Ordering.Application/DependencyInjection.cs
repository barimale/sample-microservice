using AutoMapper;
using BuildingBlocks.Behaviors;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;
using Ordering.Application.Integration;
using Ordering.Application.Profiles;
using System.Reflection;

namespace Ordering.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices
        (this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            config.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });

        services.AddFeatureManagement();

        services.AddAutoMapper(typeof(OrderProfile));

        var connectionString = configuration.GetConnectionString("StarWars");
        // "https://swapi.dev/api/"
        services.AddHttpClient<IStarWarsService, StarWarsHttpClient>((client, sp) =>
        {
            return new StarWarsHttpClient(connectionString, client);
        });
        // WIP
        //services.AddMessageBroker(configuration, Assembly.GetExecutingAssembly());

        return services;
    }
}
