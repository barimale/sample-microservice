namespace BuildingBlocks.Application.Services
{
    public class ConsulConfig
    {
        public ConsulConfig()
        {
            // intentionally left blank
        }

        public string ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceHost { get; set; } 
        public int ServicePort { get; set; } 
        public string HealthCheckUrl { get; set; } 
        public int HealthCheckIntervalSeconds { get; set; } 
        public int HealthCheckTimeoutSeconds { get; set; }
    }
}
