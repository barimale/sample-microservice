using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Ordering.Domain.Events.OrderEvents;

/// <summary>
/// Event used when the grace period order is confirmed
/// </summary>
public class OrderStatusChangedToAwaitingValidationDomainEvent
        : INotification
{
    public int OrderId { get; }
    public IEnumerable<OrderItem> OrderItems { get; }

    public OrderStatusChangedToAwaitingValidationDomainEvent(int orderId,
        IEnumerable<OrderItem> orderItems)
    {
        OrderId = orderId;
        OrderItems = orderItems;
    }
}
