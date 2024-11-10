using BuildingBlocks.API.Pagination;
using BuildingBlocks.Application.CQRS;
using Microsoft.Extensions.Logging;
using Ordering.Application.CQRS.Queries;
using Ordering.Application.Dtos;
using Ordering.Application.Integration;
using Ordering.Domain.AggregatesModel.BuyerAggregate;

namespace Ordering.Application.CQRS.QueryHandlers;
public class DummyBuyerExampleHandler(IStarWarsService starWarsService, IBuyerRepository repo, ILogger<DummyBuyerExampleHandler> logger)
    : IQueryHandler<DummyBuyersExample, DummyBuyersExampleResult>
{
    public async Task<DummyBuyersExampleResult> Handle(DummyBuyersExample query, CancellationToken cancellationToken)
    {
        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var results1 = await repo.FindAsync("asdadsads");
        var results2 = starWarsService.GetPlanet("1");

        return new DummyBuyersExampleResult(
            new PaginatedResult<OrderDto>(
                pageIndex,
                pageSize,
                1,
                null));
    }
}
