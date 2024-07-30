﻿using Carter;
using Mapster;
using MediatR;
using Ordering.API.API.Model;
using Ordering.API.API.v1._0.order_endpoint.delete_orders.Filter;
using Ordering.API.Integration;
using Ordering.Application.CQRS.Commands;
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
        app.MapPost("/orders", async (CreateOrderRequest request, ISender sender, IStarWarsService service) =>
        {
            var command = request.Adapt<CreateOrderCommand>();

            var res = await service.GetPeople("1");

            var result = await sender.Send(command);

            var response = result.Adapt<CreateOrderResponse>();

            return Results.Created($"/orders/{response.Id}", response);
        })
        .WithName("CreateOrder")
        .Produces<CreateOrderResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .AddEndpointFilter<CreateOrderRequestIsValidFilter>()
        .WithSummary("Create Order")
        .WithDescription("Create Order");
    }
}