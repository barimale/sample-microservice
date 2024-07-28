using Ordering.Domain.AggregatesModel.OrderAggregate;
using TypeGen.Core.TypeAnnotations;

namespace Ordering.Application.Model
{
    [ExportTsInterface]
    public record class CreateOrderRequest(Order Order); // not order, field by field here

}
