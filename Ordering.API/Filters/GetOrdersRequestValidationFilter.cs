using BuildingBlocks.API.Pagination;
using Ordering.API.Validators;

namespace Ordering.API.Filters
{
    public class GetOrdersRequestValidationFilter : IEndpointFilter
    {
        private readonly ILogger _logger;
        private readonly GetOrdersCommandValidator _getOrdersCommandValidator;

        public GetOrdersRequestValidationFilter(
            ILoggerFactory loggerFactory,
            GetOrdersCommandValidator getOrdersCommandValidator)
        {
            _logger = loggerFactory.CreateLogger<CreateOrderRequestValidationFilter>();
            _getOrdersCommandValidator = getOrdersCommandValidator;
        }

        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext efiContext,
            EndpointFilterDelegate next)
        {
            var command = efiContext.GetArgument<PaginationRequest>(0);
            var validationResult = await _getOrdersCommandValidator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                _logger.LogWarning(validationResult.ToString());

                return Results.Problem(
                    validationResult
                    .Errors
                    .Select(p => p.ErrorMessage.ToString())
                    .First());

            }

            return await next(efiContext);
        }
    }
}