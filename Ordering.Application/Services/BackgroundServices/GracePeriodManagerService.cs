using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client.Events;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Ordering.Application.CQRS.Queries;
using BuildingBlocks.Application.Services;
using BuildingBlocks.Application.Services.RabbitMq;

namespace Ordering.Application.Services.BackgroundServices
{
    public class GracePeriodManagerService : BackgroundService
    {
        private readonly ILogger<GracePeriodManagerService> _logger;
        private readonly IOptions<OrderingBackgroundSettings> _settings;
        private readonly PublishToChannelService publishToChannelService;
        private readonly SubscribeToChannelService subscribeToChannelService;
        private readonly IServiceProvider _serviceProvider;

        public GracePeriodManagerService(IOptions<OrderingBackgroundSettings> settings,
                                         ILogger<GracePeriodManagerService> logger,
                                         IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _settings = settings;
            _logger = logger;
            publishToChannelService = new PublishToChannelService(_settings.Value.HostName);
            subscribeToChannelService = new SubscribeToChannelService(_settings.Value.HostName);
            subscribeToChannelService.CreateChannel(_settings.Value.ChannelName);
            publishToChannelService.CreateChannel(_settings.Value.ChannelName);
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogDebug($"GracePeriodManagerService is starting.");

            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogDebug("Begin Register call from method ExecuteAsync");
            }

            Console.WriteLine(" [*] Waiting for messages.");

            var consumer = new EventingBasicConsumer(subscribeToChannelService.Channel);
            consumer.Received += (model, ea) =>
            {
                // to event
                using (var scope = _serviceProvider.CreateScope())
                {
                    var mediator = scope.ServiceProvider.GetRequiredService<ISender>();
                    mediator.Send(new DummyBuyersExample(new BuildingBlocks.API.Pagination.PaginationRequest(1, 10)));
                }
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                _logger.LogDebug($" [x] Received {message}");

            };

            subscribeToChannelService.Consume(consumer);

            // --------------------- end consumer ------------------------

            stoppingToken.Register(() =>
                _logger.LogDebug($" GracePeriod background task is stopping."));

            while (!stoppingToken.IsCancellationRequested)
            {
                //_logger.LogDebug($"GracePeriod task doing background work.");


                //const string message2 = "Hello World!";
                //publishToChannelService.Send(message2);
                //Console.WriteLine($" [x] Sent {message2}");

                try
                {
                    await Task.Delay(_settings.Value.CheckUpdateTime, stoppingToken);
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
