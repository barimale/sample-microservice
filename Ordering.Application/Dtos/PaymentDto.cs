using TypeGen.Core.TypeAnnotations;

namespace Ordering.Application.Dtos;

[ExportTsInterface]
public record PaymentDto(string CardName, string CardNumber, string Expiration, string Cvv, int PaymentMethod);
