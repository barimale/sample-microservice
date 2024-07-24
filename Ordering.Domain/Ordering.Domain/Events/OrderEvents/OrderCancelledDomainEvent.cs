using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Ordering.Domain.Events.OrderEvents;

public class OrderCancelledDomainEvent : INotification
{
    public Order Order { get; }

    public OrderCancelledDomainEvent(Order order)
    {
        Order = order;
    }
}

