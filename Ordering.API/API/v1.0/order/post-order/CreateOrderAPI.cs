﻿using Carter;
using Mapster;
using MediatR;
using Ordering.API.API.Model;
using Ordering.API.Filters;
using Ordering.Application.CQRS.Commands;
using Ordering.Application.Integration;
using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Ordering.API.Endpoints;

//- Accepts a CreateOrderRequest object.
//- Maps the request to a CreateOrderCommand.
//- Uses MediatR to send the command to the corresponding handler.
//- Returns a response with the created order's ID.

public class CreateOrder : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/orders", async (CreateOrderRequest request, ISender sender, IStarWarsService service, ILogger<CreateOrder> logger) =>
        {
            CreateOrderCommand command = request.Adapt<CreateOrderCommand>();

            var res = await service.GetPeople("1");
            logger.LogTrace("This is a Trace log, the most detailed information.");
            logger.LogDebug("This is a Debug log, useful for debugging.");
            logger.LogInformation("This is an Information log, general info about app flow.");
            logger.LogWarning("This is a Warning log, indicating a potential issue.");
            logger.LogError("This is an Error log, indicating a failure in the current operation.");
            logger.LogCritical("This is a Critical log, indicating a serious failure in the application.");
            var result = await sender.Send(command);

            var response = result.Adapt<CreateOrderResponse>();

            return Results.Created($"/orders/{response.Id}", response);
        })
        .WithName("CreateOrder")
        .Produces<CreateOrderResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .AddEndpointFilter<CreateOrderRequestValidationFilter>()
        .WithSummary("Create Order")
        .WithDescription("Create Order");
    }
}