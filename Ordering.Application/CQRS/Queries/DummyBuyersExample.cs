using BuildingBlocks.CQRS;
using BuildingBlocks.Pagination;
using Ordering.Application.Dtos;

namespace Ordering.Application.CQRS.Queries;

public class DummyBuyersExample
    : IQuery<DummyBuyersExampleResult>
{
    public DummyBuyersExample(PaginationRequest aginationRequest)
    {
        PaginationRequest = aginationRequest;
    }

    public PaginationRequest PaginationRequest { get; set; }
}

public class DummyBuyersExampleResult
{
    public DummyBuyersExampleResult()
    {
        //intentionally left blank
    }
    public DummyBuyersExampleResult(PaginatedResult<OrderDto> orders)
    {
        this.Orders = orders;
    }

    public PaginatedResult<OrderDto> Orders { get; set; }
}