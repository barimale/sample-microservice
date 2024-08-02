﻿using BuildingBlocks.CQRS;
using BuildingBlocks.Pagination;
using Ordering.Application.Dtos;

namespace Ordering.Application.CQRS.Queries;

public class GetOrdersQuery
    : IQuery<GetOrdersResult>
{
    public GetOrdersQuery(PaginationRequest aginationRequest)
    {
        PaginationRequest = aginationRequest;
    }

    public PaginationRequest PaginationRequest { get; set; }
}

public class GetOrdersResult
{
    public GetOrdersResult(PaginatedResult<OrderDto> orders)
    {
        this.Orders = orders;
    }
    
    public PaginatedResult<OrderDto> Orders { get; set; }
}