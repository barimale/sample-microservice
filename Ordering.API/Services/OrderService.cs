using Ordering.API.Exceptions;
using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Ordering.API.Services
{
    public class OrderService : IOrderService
    {
        public Task<Order> AddAsync(Order order)
        {
            throw new AddOrderException();
        }

        public Task RemoveAsync(Order order)
        {
            return Task.CompletedTask;
        }
    }
}
