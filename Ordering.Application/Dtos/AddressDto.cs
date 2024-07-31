using TypeGen.Core.TypeAnnotations;

namespace Ordering.Application.Dtos;

[ExportTsInterface]
public record AddressDto(string FirstName, string LastName, string EmailAddress, string AddressLine, string Country, string State, string ZipCode);
