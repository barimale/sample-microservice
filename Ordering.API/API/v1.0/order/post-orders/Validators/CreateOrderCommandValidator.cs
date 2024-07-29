using FluentValidation;
using Ordering.API.API.Model;
using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Ordering.API.API.v1._0.order_endpoint.post_orders.Validators
{
    public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderRequestValidator()
        {
            RuleFor(exp => exp.Description)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(20);
        }
    }
}
