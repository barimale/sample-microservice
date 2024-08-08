using BuildingBlocks.CQRS;
using BuildingBlocks.Pagination;
using Microsoft.Extensions.Logging;
using Ordering.Application.CQRS.Queries;
using Ordering.Application.Dtos;

namespace Ordering.Application.CQRS.QueryHandlers;
public class DummyBuyerExampleHandler(ILogger<DummyBuyerExampleHandler> logger)
    : IQueryHandler<DummyBuyersExample, DummyBuyersExampleResult>
{
    public async Task<DummyBuyersExampleResult> Handle(DummyBuyersExample query, CancellationToken cancellationToken)
    {
        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        return new DummyBuyersExampleResult(
            new PaginatedResult<OrderDto>(
                pageIndex,
                pageSize,
                1,
                null));
    }
}
