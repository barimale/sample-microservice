using AutoMapper;
using BuildingBlocks.CQRS;
using Ordering.Application.CQRS.Commands;
using Ordering.Domain.AggregatesModel.OrderAggregate;
using Ordering.Infrastructure;

namespace Ordering.Application.CQRS.CommandHandlers;
public class CreateOrderHandler(OrderingContext dbContext)
    : ICommandHandler<CreateOrderCommand, CreateOrderResult>
{
    public async Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        //Arrange
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
        //Act 
        var order = new Order("1", "fakeName", 
            new Address(
                street, city, state, country, zipcode), cardTypeId, cardNumber, cardSecurityNumber, cardHolderName, cardExpiration, description: description);

        //var address = new Address(message.Street, message.City, message.State, message.Country, message.ZipCode);
        //var order = new Order(message.UserId, message.UserName, address, message.CardTypeId, message.CardNumber, message.CardSecurityNumber, message.CardHolderName, message.CardExpiration);

        foreach (var item in command.OrderItems)
        {
            order.AddOrderItem(1, "item.ProductName", 5, 0, "item.PictureUrl", 5);
        }

        var result = dbContext.Orders.Add(order);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateOrderResult(result.Entity.Id);
    }
}
