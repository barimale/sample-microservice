using BuildingBlocks.CQRS;
using Ordering.Application.CQRS.Commands;
using Ordering.Infrastructure;

namespace Ordering.Application.Orders.Commands.CreateOrder;
public class CreateOrderHandler(OrderingContext dbContext)
    : ICommandHandler<CreateOrderCommand, CreateOrderResult>
{
    public async Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        //create Order entity from command object
        //save to database
        //return result 

        //var order = CreateNewOrder(command.Order);

        dbContext.Orders.Add(command.Order);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateOrderResult(Guid.NewGuid());
    }
}
