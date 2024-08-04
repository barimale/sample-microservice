using AutoMapper;
using BuildingBlocks.Pagination;
using Carter;
using MediatR;
using Microsoft.AspNetCore.HttpLogging;
using Ordering.API.API.Model;
using Ordering.Application.CQRS.Queries;
using Ordering.Application.Dtos;

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
            try
            {
                var result = await sender.Send(new GetOrdersQuery(request));

                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }

            return Results.BadRequest();
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
