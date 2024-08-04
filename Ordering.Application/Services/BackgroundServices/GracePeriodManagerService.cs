using BuildingBlocks.Services;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Services.BackgroundServices
{
    public class GracePeriodManagerService : BackgroundService
    {
        private readonly ILogger<GracePeriodManagerService> _logger;
        private readonly OrderingBackgroundSettings _settings = new OrderingBackgroundSettings();

        //private readonly IEventBus _eventBuskk

        public GracePeriodManagerService(
                                         ILogger<GracePeriodManagerService> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogDebug($"GracePeriodManagerService is starting.");

            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogDebug("Begin Register call from method ExecuteAsync");
            }

            stoppingToken.Register(() =>
                _logger.LogDebug($" GracePeriod background task is stopping."));

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogDebug($"GracePeriod task doing background work.");

                // This eShopOnContainers method is querying a database table
                // and publishing events into the Event Bus (RabbitMQ / ServiceBus)
                //CheckConfirmedGracePeriodOrders();
                // subscribe here
                try
                {
                    await Task.Delay(_settings.CheckUpdateTime, stoppingToken);
                }
                catch (TaskCanceledException exception)
                {
                    _logger.LogCritical(exception, "TaskCanceledException Error", exception.Message);
                }
            }

            _logger.LogDebug($"GracePeriod background task is stopping.");
        }

        public interface IEventBus
        {
        }
    }
}
