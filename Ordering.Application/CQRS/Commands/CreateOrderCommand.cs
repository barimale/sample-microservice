using BuildingBlocks.Application.CQRS;
using FluentValidation;
using Ordering.Application.Dtos;
using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Ordering.Application.CQRS.Commands;

public class CreateOrderCommand : ICommand<CreateOrderResult>
{
    public CreateOrderCommand()
    {
        // intentionally left blank
    }

    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public AddressDto ShippingAddress { get; set; }
    public AddressDto BillingAddress { get; set; }
    public PaymentDto Payment { get; set; }
    public Dtos.OrderStatus Status { get; set; }
    public List<OrderItemDto> OrderItems { get; set; }
    public string Description { get; set; }
}


public class CreateOrderResult
{
    public CreateOrderResult()
    {
        // intentionally left blank
    }

    public CreateOrderResult(int id)
    {
        this.Id = id;
    }

    public int Id { get; set; }
}

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        //RuleFor(x => x.Order.OrderName).NotEmpty().WithMessage("Name is required");
        //RuleFor(x => x.Order.CustomerId).NotNull().WithMessage("CustomerId is required");
        //RuleFor(x => x.Order.OrderItems).NotEmpty().WithMessage("OrderItems should not be empty");
    }
}