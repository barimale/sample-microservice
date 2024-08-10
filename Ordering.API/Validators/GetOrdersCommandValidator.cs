using BuildingBlocks.API.Pagination;
using FluentValidation;
using Ordering.API.Model.order;

namespace Ordering.API.Validators
{
    public class GetOrdersCommandValidator : AbstractValidator<PaginationRequest>
    {
        public GetOrdersCommandValidator()
        {
            RuleFor(exp => exp.PageIndex)
                .InclusiveBetween(0, int.MaxValue);
            RuleFor(exp => exp.PageSize)
                .InclusiveBetween(0, int.MaxValue);
        }
    }
}
