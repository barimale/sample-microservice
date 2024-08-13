using BuildingBlocks.API.Pagination;
using BuildingBlocks.Application.CQRS;
using Ordering.Application.Dtos;

namespace Ordering.Application.CQRS.Queries;

public class GetOrdersQuery
    : IQuery<GetOrdersResult>
{
    public GetOrdersQuery()
    {
        PaginationRequest = new PaginationRequest();
    }

    public GetOrdersQuery(PaginationRequest paginationRequest)
    {
        PaginationRequest = paginationRequest;
    }

    public PaginationRequest PaginationRequest { get; set; }
}

public class GetOrdersResult
{
    public GetOrdersResult()
    {
        //intentionally left blank
    }
    public GetOrdersResult(PaginatedResult<OrderDto> orders)
    {
        this.Orders = orders;
    }
    
    public PaginatedResult<OrderDto> Orders { get; set; }
}