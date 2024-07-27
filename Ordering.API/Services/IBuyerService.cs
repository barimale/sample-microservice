using Ordering.Domain.AggregatesModel.BuyerAggregate;

namespace Ordering.API.Services
{
    public interface IBuyerService
    {
        Task<Buyer> AddAsync(Buyer buyer);
        Task RemoveAsync(Buyer buyer);
    }
}