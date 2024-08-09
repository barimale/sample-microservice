using Ordering.Application.Dtos;
using TypeGen.Core.TypeAnnotations;

namespace Ordering.API.Model.order
{
    [ExportTsInterface]
    public class CreateOrderRequest
    {
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
}
