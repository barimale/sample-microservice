using AutoMapper;
using BuildingBlocks.API.Pagination;
using BuildingBlocks.Application.CQRS;
using Microsoft.Extensions.Logging;
using Ordering.Application.CQRS.Queries;
using Ordering.Application.Dtos;
using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Ordering.Application.CQRS.QueryHandlers;
public class GetOrdersHandler(IOrderRepository orderRepository, IMapper mapper, ILogger<GetOrdersHandler> logger)
    : IQueryHandler<GetOrdersQuery, GetOrdersResult>
     
{
    public async Task<GetOrdersResult> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
    {
        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var orders = await orderRepository.GetAllAsync(pageIndex, pageSize);
        var mapped = mapper.Map<List<OrderDto>>(orders);

        return new GetOrdersResult(
            new PaginatedResult<OrderDto>(
                pageIndex,
                pageSize,
                orders.Count,
                mapped));
    }
}
