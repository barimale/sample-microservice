﻿using TypeGen.Core.TypeAnnotations;

namespace Ordering.Application.Dtos;

[ExportTsInterface]
public class OrderItemDto
{
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
