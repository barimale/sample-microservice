using BuildingBlocks.Domain.SeedWork;

namespace BuildingBlocks.Domain.Request
{
    public class Request : Entity, IAggregateRoot
    {
        public Guid CorrelationId { get; set; }
        public string Content { get; set; }
        public DateTimeOffset ExecutionTime { get; set; }
    }
}
