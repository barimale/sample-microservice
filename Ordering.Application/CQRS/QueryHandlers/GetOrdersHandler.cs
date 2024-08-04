using AutoMapper;
using BuildingBlocks.CQRS;
using BuildingBlocks.Pagination;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ordering.Application.CQRS.Queries;
using Ordering.Application.Dtos;
using Ordering.Infrastructure;

namespace Ordering.Application.CQRS.QueryHandlers;
public class GetOrdersHandler(OrderingContext dbContext, IMapper mapper, ILogger<GetOrdersHandler> logger)
    : IQueryHandler<GetOrdersQuery, GetOrdersResult>
{
    public async Task<GetOrdersResult> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
    {
        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var orders = await dbContext.Orders
                       .Include(o => o.OrderItems)
                       .OrderBy(o => o.OrderDate)
                       .Skip(pageSize * pageIndex)
                       .Take(pageSize)
                       .ToListAsync(cancellationToken);

        var mapped = mapper.Map<List<OrderDto>>(orders);

        return new GetOrdersResult(
            new PaginatedResult<OrderDto>(
                pageIndex,
                pageSize,
                orders.Count,
                mapped));
    }
}
