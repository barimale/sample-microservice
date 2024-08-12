using BuildingBlocks.Domain.SeedWork;

namespace BuildingBlocks.Domain.Response
{
    public class Response : Entity, IAggregateRoot
    {
        public Guid CorrelationId { get; set; }
        public string Content { get; set; }
        public DateTimeOffset ExecutionTime { get; set; }
    }
}
