using BuildingBlocks.CQRS;
using BuildingBlocks.Pagination;
using Microsoft.EntityFrameworkCore;
using Ordering.Application.CQRS.Queries;
using Ordering.Application.Dtos;
using Ordering.Infrastructure;

namespace Ordering.Application.Orders.Queries.GetOrders;
public class GetOrdersHandler(OrderingContext dbContext)
    : IQueryHandler<GetOrdersQuery, GetOrdersResult>
{
    public async Task<GetOrdersResult> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
    {
        // get orders with pagination
        // return result

        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        //var totalCount = await dbContext.Orders.LongCountAsync(cancellationToken);

        var orders = await dbContext.Orders
                       .Include(o => o.OrderItems)
                       .OrderBy(o => o.OrderDate)
                       .Skip(pageSize * pageIndex)
                       .Take(pageSize)
                       .ToListAsync(cancellationToken);

        return new GetOrdersResult(
            new PaginatedResult<OrderDto>(
                pageIndex,
                pageSize,
                orders.Count,
                null));        
    }
}
