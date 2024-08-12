namespace BuildingBlocks.Application.Services
{
    public class ConsulConfig
    {
        public ConsulConfig()
        {
            // intentionally left blank
        }

        public string ServiceId { get; set; } = "order-service";
        public string ServiceName { get; set; } = "Order service";
        public string ServiceHost { get; set; } = "localhost";
        public int ServicePort { get; set; } = 7229;
        public string HealthCheckUrl { get; set; } = "api/healthcheck";
        public int HealthCheckIntervalSeconds { get; set; } = 10;
        public int HealthCheckTimeoutSeconds { get; set; } = 1;
    }
}
