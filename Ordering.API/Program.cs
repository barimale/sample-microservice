
using BuildingBlocks.Behaviors;
using Carter;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NLog.Extensions.Logging;
using NLog;
using NLog.Web;
using Ordering.Application;
using Ordering.Infrastructure;
using System;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace Ordering.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var builder = WebApplication.CreateBuilder(args);

                LogManager.Configuration = new NLogLoggingConfiguration(
                    builder.Configuration.GetSection("NLog"));

                builder.Services.AddHttpLogging(logging =>
                {
                    logging.LoggingFields = HttpLoggingFields.All;
                    //logging.RequestHeaders.Add("sec-ch-ua");
                    //logging.ResponseHeaders.Add("MyResponseHeader");
                    //logging.MediaTypeOptions.AddText("application/javascript");
                    logging.RequestBodyLogLimit = 4096;
                    logging.ResponseBodyLogLimit = 4096;
                });

                // Add services to the container.
                // AddSecondWebApiClient
                // AddRabbitMqClient for choreography
                // NLog: Setup NLog for Dependency injection
                builder.Logging.ClearProviders();
                builder.Logging.SetMinimumLevel(LogLevel.Trace);
                builder.Host.UseNLog();
                // add dblogging middleware here

                // validation layer as a filter defined in each minimal api
                // WIP
                var assembly = typeof(Program).Assembly;

                builder.Services
                    .AddApplicationServices(builder.Configuration)
                    .AddInfrastructureServices(builder.Configuration)
                    .AddApiServices(builder.Configuration);

                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();

                var app = builder.Build();

                app.UseHttpLogging();
                app.UseApiServices();

                // TO Seed method as is in eShop .AddMigration
                try
                {
                    using var scope = app.Services.CreateScope();
                    OrderingContext context = scope.ServiceProvider.GetRequiredService<OrderingContext>();
                    context.Database.Migrate();
                }
                catch (Exception)
                {
                    Console.WriteLine("On Migrate error");
                }

                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();

                app.Run();
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                NLog.LogManager.Shutdown();
            }
        }
    }
}
