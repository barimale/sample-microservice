using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using NLog.Extensions.Logging;
using NLog;
using NLog.Web;
using Ordering.Application;
using Ordering.Infrastructure;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;
using eShop.Ordering.API.Infrastructure;

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
                    logging.LoggingFields = HttpLoggingFields.RequestPropertiesAndHeaders | HttpLoggingFields.ResponsePropertiesAndHeaders;
                    logging.RequestBodyLogLimit = 4096;
                    logging.ResponseBodyLogLimit = 4096;
                });

                builder.Logging.ClearProviders();
                builder.Logging.SetMinimumLevel(LogLevel.Trace);
                builder.Host.UseNLog();
                // add dblogging middleware here

                var assembly = typeof(Program).Assembly;

                builder.Services
                    .AddApplicationServices(builder.Configuration)
                    .AddInfrastructureServices(builder.Configuration)
                    .AddApiServices(builder.Configuration);

                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();

                builder.Services.AddMigration<OrderingContext, OrderingContextSeed>();

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
                NLog.LogManager.Shutdown();
            }
        }
    }
}
