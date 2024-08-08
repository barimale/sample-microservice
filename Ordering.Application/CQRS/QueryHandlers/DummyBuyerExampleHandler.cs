using BuildingBlocks.CQRS;
using BuildingBlocks.Pagination;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.CQRS.Queries;
using Ordering.Application.Dtos;
using Ordering.Domain.AggregatesModel.BuyerAggregate;

namespace Ordering.Application.CQRS.QueryHandlers;
public class DummyBuyerExampleHandler(IBuyerRepository repo, ILogger<DummyBuyerExampleHandler> logger)
    : IQueryHandler<DummyBuyersExample, DummyBuyersExampleResult>
{
    public async Task<DummyBuyersExampleResult> Handle(DummyBuyersExample query, CancellationToken cancellationToken)
    {
        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        //var result = await repo.FindAsync("asdadsads");

        return new DummyBuyersExampleResult(
            new PaginatedResult<OrderDto>(
                pageIndex,
                pageSize,
                1,
                null));
    }
}
