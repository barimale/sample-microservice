using AutoMapper;
using Carter;
using MediatR;
using Microsoft.AspNetCore.HttpLogging;
using Ordering.API.Filters;
using Ordering.API.Model.order;
using Ordering.Application.CQRS.Commands;

namespace Ordering.API.Endpoints;

public class CreateOrderAPI : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/v1/orders", async (
            CreateOrderRequest request,
            ISender sender,
            IMapper mapper,
            ILogger<CreateOrderAPI> logger) =>
        {
            var command = mapper.Map<CreateOrderCommand>(request);
            var result = await sender.Send(command);

            var response = mapper.Map<CreateOrderResponse>(result);

            return Results.Created($"/orders/{response.Id}", response);
        })
        .WithName("CreateOrder")
        .Produces<CreateOrderResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithHttpLogging(HttpLoggingFields.RequestPropertiesAndHeaders)
        .AddEndpointFilter<CreateOrderRequestValidationFilter>()
        .WithHttpLogging(HttpLoggingFields.ResponsePropertiesAndHeaders).WithSummary("Get Orders")
        .WithSummary("Create Order summary")
        .WithDescription("Create Order description");
    }
}