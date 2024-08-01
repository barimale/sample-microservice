﻿using TypeGen.Core.TypeAnnotations;

namespace Ordering.API.API.Model
{
    [ExportTsInterface]
    public record class CreateOrderRequest(
        DateTime OrderDate,
        int BuyerId,
        string Description
        );

}
