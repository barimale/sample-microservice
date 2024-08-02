using BuildingBlocks.Pagination;
using Carter;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.HttpLogging;
using Ordering.Application.CQRS.Queries;
using Ordering.Application.Dtos;

namespace Ordering.API.Endpoints;

//- Accepts pagination parameters.
//- Constructs a GetOrdersQuery with these parameters.
//- Retrieves the data and returns it in a paginated format.

//public record GetOrdersRequest(PaginationRequest PaginationRequest);
public record GetOrdersResponse(
    PaginatedResult<OrderDto> Orders);

public class GetOrders : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/v1/orders",async ([AsParameters] PaginationRequest request,
                ISender sender, ILogger<GetOrders> logger) =>
                {
                    try
                    {
                        var result = await sender.Send(new GetOrdersQuery(request));

                        var response = result.Adapt<GetOrdersResponse>();
                        return Results.Ok(response);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex.Message);
                    }

                    return Results.BadRequest();
                })
        .WithName("GetOrders")
        .Produces<GetOrdersResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithHttpLogging(HttpLoggingFields.RequestPropertiesAndHeaders)
        //.AddEndpointFilter<GetOrdersFilter>()
        .WithHttpLogging(HttpLoggingFields.ResponsePropertiesAndHeaders)
        .WithSummary("Get Orders")
        .WithDescription("Get Orders");
    }
}
