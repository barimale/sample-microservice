using MediatR;

namespace Ordering.Domain.Events.OrderEvents;

/// <summary>
/// Event used when the order stock items are confirmed
/// </summary>
public class OrderStatusChangedToStockConfirmedDomainEvent
    : INotification
{
    public int OrderId { get; }

    public OrderStatusChangedToStockConfirmedDomainEvent(int orderId)
        => OrderId = orderId;
}
