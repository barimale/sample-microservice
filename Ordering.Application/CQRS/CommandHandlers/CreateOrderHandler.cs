using BuildingBlocks.CQRS;
using Ordering.Application.CQRS.Commands;
using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Ordering.Application.CQRS.CommandHandlers;
public class CreateOrderHandler(IOrderRepository orderRepository)
    : ICommandHandler<CreateOrderCommand, CreateOrderResult>
{
    public async Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var street = command.BillingAddress.AddressLine;
        var city = command.BillingAddress.Country;
        var state = command.BillingAddress.State;
        var country = command.BillingAddress.Country;
        var zipcode = command.BillingAddress.AddressLine;
        var cardTypeId = command.Payment.PaymentMethod;
        var cardNumber = command.Payment.CardNumber;
        var cardSecurityNumber = command.Payment.Cvv;
        var cardHolderName = command.Description;
        var cardExpiration = DateTime.UtcNow.AddYears(1);
        var description = command.Description;
        
        //it has to be like below 
        var order = new Order("1", "fakeName", 
            new Address(
                street, city, state, country, zipcode), cardTypeId, cardNumber, cardSecurityNumber, cardHolderName, cardExpiration, description: description);

        foreach (var item in command.OrderItems)
        {
            order.AddOrderItem(1, "item.ProductName", 5, 0, "item.PictureUrl", 5);
        }

        var result = orderRepository.Add(order);
        await orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

        return new CreateOrderResult(result.Id);
    }
}
