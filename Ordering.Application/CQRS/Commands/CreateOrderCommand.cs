using BuildingBlocks.CQRS;
using FluentValidation;
using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Ordering.Application.CQRS.Commands;

public class CreateOrderCommand : ICommand<CreateOrderResult>
{
    public CreateOrderCommand()
    {
        // intentionally left blank
    }

    public CreateOrderCommand(Order order)
    {
        Order = order;
    }

    public Order Order { get; set; }
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