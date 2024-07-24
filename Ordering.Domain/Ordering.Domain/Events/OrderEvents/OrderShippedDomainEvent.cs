using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Ordering.Domain.Events.OrderEvents;

public class OrderShippedDomainEvent : INotification
{
    public Order Order { get; }

    public OrderShippedDomainEvent(Order order)
    {
        Order = order;
    }
}
