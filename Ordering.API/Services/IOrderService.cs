using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Ordering.API.Services
{
    public interface IOrderService
    {
        Task<Order> AddAsync(Order order);
        Task RemoveAsync(Order order);
    }
}