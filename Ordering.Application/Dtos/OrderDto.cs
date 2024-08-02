using TypeGen.Core.TypeAnnotations;

namespace Ordering.Application.Dtos;

[ExportTsInterface]
public class OrderDto
{
    public OrderDto()
    {
        // intentionally left blank
    }

    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string OrderName { get; set; }
    public AddressDto ShippingAddress { get; set; }
    public AddressDto BillingAddress { get; set; }
    public PaymentDto Payment { get; set; }
    public OrderStatus Status { get; set; }
    public List<OrderItemDto> OrderItems { get; set; }
    public string Description { get; set; }
}


[ExportTsEnumAttribute]
public enum OrderStatus
{
    Draft = 1,
    Pending = 2,
    Completed = 3,
    Cancelled = 4
}