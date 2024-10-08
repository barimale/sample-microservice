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
using BuildingBlocks.API.Utilities.Healthcheck;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using BuildingBlocks.API.Middlewares.GlobalExceptions.Handler;
using Ordering.API.Middlewares;

namespace Ordering.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var builder = WebApplication.CreateBuilder(args);

                builder.Services.AddProblemDetails(options =>
                    options.CustomizeProblemDetails = ctx =>
                        ctx.ProblemDetails.Extensions.Add("nodeId", Environment.MachineName));

                builder.Services
                    .AddApplicationServices(builder.Configuration)
                    .AddInfrastructureServices(builder.Configuration)
                    .AddApiServices(builder.Configuration);

                builder.Logging.ClearProviders();
                builder.Logging.SetMinimumLevel(builder.Environment.IsDevelopment() ? LogLevel.Debug : LogLevel.Trace);
                builder.Host.UseNLog();

                var app = builder.Build();
                app.UseMiddleware<RequestResponseLoggerMiddleware>();
                app.UseExceptionHandler(options => { });

                app.UseHttpLogging();
                app.UseApiServices();

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
