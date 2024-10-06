using AutoMapper;
using BuildingBlocks.API.Pagination;
using Carter;
using MediatR;
using Microsoft.AspNetCore.HttpLogging;
using Ordering.API.Filters;
using Ordering.Application.CQRS.Queries;

namespace Ordering.API.Endpoints;

public class GetOrders : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/v1/orders", async (
            [AsParameters] PaginationRequest request,
            ISender sender,
            IMapper mapper,
            ILogger<GetOrders> logger) =>
        {
            var mapped = mapper.Map<GetOrdersQuery>(request);
            var response = await sender.Send(mapped);

            if (response is null)
                return Results.NotFound();

            return Results.Ok(response);
        })
        .WithName("GetOrders")
        .Produces<GetOrdersResult>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithHttpLogging(HttpLoggingFields.RequestPropertiesAndHeaders)
        .AddEndpointFilter<GetOrdersRequestValidationFilter>()
        .WithHttpLogging(HttpLoggingFields.ResponsePropertiesAndHeaders)
        .WithSummary("Get Orders summary")
        .WithDescription("Get Orders description");
    }
}
