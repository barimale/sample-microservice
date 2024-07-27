using Ordering.API.Exceptions;
using Ordering.Domain.AggregatesModel.BuyerAggregate;

namespace Ordering.API.Services
{
    public class BuyerService : IBuyerService
    {
        public Task<Buyer> AddAsync(Buyer buyer)
        {
            throw new AddBuyerException();
        }

        public Task RemoveAsync(Buyer buyer)
        {
            return Task.CompletedTask;
        }
    }
}
