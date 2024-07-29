using BuildingBlocks.CQRS;
using FluentValidation;
using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Ordering.Application.CQRS.Commands;

public record CreateOrderCommand(Order Order)
    : ICommand<CreateOrderResult>;

public record CreateOrderResult(Guid Id);

//public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
//{
//    public CreateOrderCommandValidator()
//    {
//        //RuleFor(x => x.Order.OrderName).NotEmpty().WithMessage("Name is required");
//        //RuleFor(x => x.Order.CustomerId).NotNull().WithMessage("CustomerId is required");
//        RuleFor(x => x.Order.OrderItems).NotEmpty().WithMessage("OrderItems should not be empty");
//    }
//}