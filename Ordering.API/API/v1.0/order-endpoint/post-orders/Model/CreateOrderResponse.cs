﻿using TypeGen.Core.TypeAnnotations;

namespace Ordering.API.API.Model
{
    [ExportTsInterface]
    public record class CreateOrderResponse(Guid Id);
}
