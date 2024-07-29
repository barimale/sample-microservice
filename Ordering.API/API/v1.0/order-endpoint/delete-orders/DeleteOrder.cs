using Carter;
using Mapster;
using MediatR;
using Ordering.API.API.v1._0.order_endpoint.delete_orders.Filter;

namespace Ordering.API.Endpoints;

//- Accepts the order ID as a parameter.
//- Constructs a DeleteOrderCommand.
//- Sends the command using MediatR.
//- Returns a success or not found response.

//public record DeleteOrderRequest(Guid Id);
public record DeleteOrderResponse(bool IsSuccess);

public class DeleteOrder : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/orders/{id}", async (Guid Id, ISender sender) =>
        {
            //var result = await sender.Send(new DeleteOrderCommand(Id));

            //var response = result.Adapt<DeleteOrderResponse>();

            return Results.Ok(null);
        })
        .WithName("DeleteOrder")
        .Produces<DeleteOrderResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .AddEndpointFilter<CreateOrderRequestIsValidFilter>()
        .WithSummary("Delete Order")
        .WithDescription("Delete Order");
    }
}
