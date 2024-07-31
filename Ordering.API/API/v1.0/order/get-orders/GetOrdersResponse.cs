using Ordering.Application.Dtos;
using TypeGen.Core.TypeAnnotations;

namespace Ordering.API.API.Model
{
    [ExportTsInterface]
    public record class GetOrdersResponse(List<OrderDto> Orders);
}
