using BuildingBlocks.CQRS;
using BuildingBlocks.Services.RabbitMq;
using Microsoft.Extensions.Options;
using Ordering.Application.CQRS.Commands;
using Ordering.Application.Services.BackgroundServices;
using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Ordering.Application.CQRS.CommandHandlers;
public class CreateOrderHandler(IOrderRepository orderRepository, IOptions<OrderingBackgroundSettings> _settings)
    : ICommandHandler<CreateOrderCommand, CreateOrderResult>
{
    private PublishToChannelService publishToChannelService;

    public async Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        publishToChannelService = new PublishToChannelService(_settings.Value.HostName);
        publishToChannelService.CreateChannel(_settings.Value.ChannelName);

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
        const string message2 = "From Command Handler Hello World!";
        publishToChannelService.Send(message2);
        Console.WriteLine($" [x] Sent {message2}");
        return new CreateOrderResult(result.Id);
    }
}
