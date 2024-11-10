using BuildingBlocks.Application.Behaviors;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;
using Ordering.Application.Behaviours;
using Ordering.Application.Integration;
using Ordering.Application.Profiles;
using Ordering.Application.Services.BackgroundServices;
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
            config.AddOpenBehavior(typeof(TransactionBehavior<,>));
        });

        services.AddFeatureManagement();
        services.AddAutoMapper(typeof(OrderProfile));

        var connectionString = configuration.GetConnectionString("StarWars");

        services.AddHttpClient<IStarWarsService, StarWarsHttpClient>((client, sp) =>
        {
            return new StarWarsHttpClient(connectionString, client);
        }).SetHandlerLifetime(TimeSpan.FromMinutes(2)); ;
        // WIP
        //services.AddMessageBroker(configuration, Assembly.GetExecutingAssembly());
        string hostName = configuration.GetValue<string>("AppSettings:HostName");

        services.AddHostedService<GracePeriodManagerService>();
        services.Configure<OrderingBackgroundSettings>(
            configuration.GetSection("AppSettings"));

        return services;
    }
}
