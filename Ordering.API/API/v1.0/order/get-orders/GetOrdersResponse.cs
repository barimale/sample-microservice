using Ordering.Application.Dtos;
using TypeGen.Core.TypeAnnotations;

namespace Ordering.API.API.Model
{
    [ExportTsInterface]
    public class GetOrdersResponse
    {
        public GetOrdersResponse()
        {
            // intentionally left blank
        }

        public GetOrdersResponse(List<OrderDto> orders)
        {
            this.Orders = orders;
        }

        public List<OrderDto> Orders { get; set; }
    }
}
