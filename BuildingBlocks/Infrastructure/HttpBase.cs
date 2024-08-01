using BuildingBlocks.SeedWork;

namespace BuildingBlocks.Infrastructure
{
    public abstract class HttpBase: Entity
    {
        public string Header;
        public DateTimeOffset executionTime;
        public string Body;
    }
}
