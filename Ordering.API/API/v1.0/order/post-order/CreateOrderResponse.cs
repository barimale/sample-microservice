using TypeGen.Core.TypeAnnotations;

namespace Ordering.API.API.Model
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
            this.Id = id;
        }

        public int Id { get; set; }
    }
}
