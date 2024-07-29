using FluentValidation;
using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Ordering.API.API.v1._0.order_endpoint.post_orders.Validators
{
    public class CreateOrderCommandValidator : AbstractValidator<Order>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(exp => exp.Description)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(20);
        }
    }
}
