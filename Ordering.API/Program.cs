using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using NLog.Extensions.Logging;
using NLog;
using NLog.Web;
using Ordering.Application;
using Ordering.Infrastructure;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;
using Ordering.API.Extensions;
using Ordering.API.SeedWork;
using BuildingBlocks.API.Exceptions.Handler;
using BuildingBlocks.API.Utilities.Healthcheck;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

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

                builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

                builder.Services.AddHttpLogging(logging =>
                {
                    logging.LoggingFields = HttpLoggingFields.RequestPropertiesAndHeaders | HttpLoggingFields.ResponsePropertiesAndHeaders;
                    logging.RequestBodyLogLimit = 4096;
                    logging.ResponseBodyLogLimit = 4096;
                });

                builder.Logging.ClearProviders();
                builder.Logging.SetMinimumLevel(builder.Environment.IsDevelopment() ? LogLevel.Debug : LogLevel.Trace);
                builder.Host.UseNLog();

                builder.Services
                    .AddApplicationServices(builder.Configuration)
                    .AddInfrastructureServices(builder.Configuration)
                    .AddApiServices(builder.Configuration);

                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen(options =>
                {
                    options.DocumentFilter<HealthChecksDocumentFilter>();
                    options.EnableAnnotations();
                });

                builder.Services.AddMigration<OrderingContext, OrderingContextSeed>();

                var app = builder.Build();
                app.UseExceptionHandler(options => { });

                app.UseHttpLogging();
                app.UseApiServices();

                // In production -> execute migrations via script
                if (app.Environment.IsDevelopment())
                {
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
                }

                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();
                app.MapHealthChecks(HeartbeatUtility.Path, new HealthCheckOptions()
                {
                    ResponseWriter = HeartbeatUtility.WriteResponse
                });

                app.Run();
            }
            finally
            {
                LogManager.Shutdown();
            }
        }
    }
}
