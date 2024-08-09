using TypeGen.Core.TypeAnnotations;

namespace Ordering.API.Model.order
{
    [ExportTsInterface]
    public class CreateOrderResponse
    {
        public CreateOrderResponse()
        {
            // intentionally left blank
        }

        public CreateOrderResponse(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
