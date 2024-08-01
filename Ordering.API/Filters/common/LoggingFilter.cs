using Ordering.API.API.Model;
using Ordering.API.API.Model;
using Ordering.API.Validators;

namespace Ordering.API.Filters.common
{
    public class LoggingFilter : IEndpointFilter
    {
        private readonly ILogger _logger;
        private readonly CreateOrderRequestValidator _createOrderRequestValidator;

        public LoggingFilter(
            ILoggerFactory loggerFactory,
            CreateOrderRequestValidator createOrderRequestValidator)
        {
            _logger = loggerFactory.CreateLogger<CreateOrderRequestValidationFilter>();
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
                //return Results.Problem(validationResult.Errors.Select(p => p.ErrorMessage.ToString()));
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