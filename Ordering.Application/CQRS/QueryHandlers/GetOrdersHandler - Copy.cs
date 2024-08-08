using AutoMapper;
using BuildingBlocks.CQRS;
using BuildingBlocks.Pagination;
using Microsoft.Extensions.Logging;
using Ordering.Application.CQRS.Queries;
using Ordering.Application.Dtos;
using Ordering.Domain.AggregatesModel.BuyerAggregate;

namespace Ordering.Application.CQRS.QueryHandlers;
public class GetOrdersHandler2(IBuyerRepository buyerRepository, IMapper mapper, ILogger<GetOrdersHandler> logger)
    : IQueryHandler<DummyBuyersExample, DummyBuyersExampleResult>
{
    public async Task<DummyBuyersExampleResult> Handle(DummyBuyersExample query, CancellationToken cancellationToken)
    {
        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var buyers = await buyerRepository.FindAsync("string");

        return new DummyBuyersExampleResult(
            new PaginatedResult<OrderDto>(
                pageIndex,
                pageSize,
                1,
                null));
    }
}
