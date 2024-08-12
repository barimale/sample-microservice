using Consul;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BuildingBlocks.Application.Services
{
    public class ConsulHostedService : IHostedService
    {
        private readonly IConsulClient _consulClient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<ConsulHostedService> _logger;
        private readonly IOptions<ConsulConfig> _serviceConfig;
        public ConsulHostedService(IOptions<ConsulConfig> serviceConfig, IConsulClient consulClient, IConfiguration configuration, ILogger<ConsulHostedService> logger)
        {
            _serviceConfig = serviceConfig;
            _consulClient = consulClient;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                var registration = new AgentServiceRegistration
                {
                    ID = _serviceConfig.Value.ServiceId,
                    Name = _serviceConfig.Value.ServiceName,
                    Address = _serviceConfig.Value.ServiceHost,
                    Port = _serviceConfig.Value.ServicePort
                };
                // wip
                var check = new AgentServiceCheck
                {
                    HTTP = _serviceConfig.Value.HealthCheckUrl,
                    Interval = TimeSpan.FromSeconds(_serviceConfig.Value.HealthCheckIntervalSeconds),
                    Timeout = TimeSpan.FromSeconds(_serviceConfig.Value.HealthCheckTimeoutSeconds)
                };

                registration.Checks = new[] { check };

                _logger.LogInformation($"Registering service with Consul: {registration.Name}");

                await _consulClient.Agent.ServiceDeregister(registration.ID, cancellationToken);
                await _consulClient.Agent.ServiceRegister(registration, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            var registration = new AgentServiceRegistration { ID = _serviceConfig.Value.ServiceId };

            _logger.LogInformation($"Deregistering service from Consul: {registration.ID}");

            await _consulClient.Agent.ServiceDeregister(registration.ID, cancellationToken);
        }
    }
}
