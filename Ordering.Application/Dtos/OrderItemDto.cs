using TypeGen.Core.TypeAnnotations;

namespace Ordering.Application.Dtos;

[ExportTsInterface]
public record OrderItemDto(Guid OrderId, Guid ProductId, int Quantity, decimal Price);
