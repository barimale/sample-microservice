using TypeGen.Core.TypeAnnotations;

namespace Ordering.Application.Dtos;

[ExportTsInterface]
public class OrderItemDto
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string ProductName { get; set; }
    public string PictureUrl { get; set; }
}
