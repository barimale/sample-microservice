using AutoMapper;
using BuildingBlocks.API.Pagination;
using Carter;
using MediatR;
using Microsoft.AspNetCore.HttpLogging;
using Ordering.Application.CQRS.Queries;

namespace Ordering.API.Endpoints;

public class GetOrders : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/v1/orders",async (
            [AsParameters] PaginationRequest request,
            ISender sender,
            IMapper mapper,
            ILogger<GetOrders> logger) =>
        {
            var response = await sender.Send(new GetOrdersQuery(request));
            return Results.Ok(response);
        })
        .WithName("GetOrders")
        .Produces<GetOrdersResult>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithHttpLogging(HttpLoggingFields.RequestPropertiesAndHeaders)
        //.AddEndpointFilter<GetOrdersFilter>()
        .WithHttpLogging(HttpLoggingFields.ResponsePropertiesAndHeaders)
        .WithSummary("Get Orders")
        .WithDescription("Get Orders");
    }
}
