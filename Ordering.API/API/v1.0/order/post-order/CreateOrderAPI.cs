using AutoMapper;
using Carter;
using MediatR;
using Microsoft.AspNetCore.HttpLogging;
using Ordering.API.API.Model;
using Ordering.API.Filters;
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
            try
            {
                var command = mapper.Map<CreateOrderCommand>(request);
                var result = await sender.Send(command);

                var response = mapper.Map<CreateOrderResponse>(result);

                return Results.Created($"/orders/{response.Id}", response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }

            return Results.BadRequest();
        })
        .WithName("CreateOrder")
        .Produces<CreateOrderResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithHttpLogging(HttpLoggingFields.RequestPropertiesAndHeaders)
        .AddEndpointFilter<CreateOrderRequestValidationFilter>()
        .WithHttpLogging(HttpLoggingFields.ResponsePropertiesAndHeaders).WithSummary("Get Orders")
        .WithSummary("Create Order")
        .WithDescription("Create Order");
    }
}