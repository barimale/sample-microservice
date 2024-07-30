using Ordering.API.API.Model;
using Ordering.API.API.v1._0.order_endpoint.post_orders.Validators;

namespace Ordering.API.Filters
{
    public class GetOrdersFilter : IEndpointFilter
    {
        private readonly ILogger _logger;
        private readonly CreateOrderRequestValidator _createOrderRequestValidator;

        public GetOrdersFilter(
            ILoggerFactory loggerFactory,
            CreateOrderRequestValidator createOrderRequestValidator)
        {
            _logger = loggerFactory.CreateLogger<GetOrdersFilter>();
            _createOrderRequestValidator = createOrderRequestValidator;
        }

        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext efiContext,
            EndpointFilterDelegate next)
        {
            var command = efiContext.GetArgument<CreateOrderRequest>(0);
            var validationResult = await _createOrderRequestValidator.ValidateAsync(command);

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