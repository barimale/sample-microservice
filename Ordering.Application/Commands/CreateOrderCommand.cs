using BuildingBlocks.CQRS;
using FluentValidation;
using Ordering.Application.Dtos;

namespace Ordering.Application.Commands;

public record CreateOrderCommand(OrderRequest Order)
    : ICommand<CreateOrderResult>;

public record CreateOrderResult(Guid Id);

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.Order.OrderName).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Order.CustomerId).NotNull().WithMessage("CustomerId is required");
        RuleFor(x => x.Order.OrderItems).NotEmpty().WithMessage("OrderItems should not be empty");
    }
}