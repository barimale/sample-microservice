using FluentValidation;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Ordering.API.API.v1._0.order_endpoint.post_orders.Validators;
using Ordering.Application.CQRS.Commands;

namespace Ordering.API.API.v1._0.order_endpoint.delete_orders.Filter
{
    public abstract class ABCEndpointFilters : IEndpointFilter
    {
        protected readonly ILogger Logger;
        private readonly string _methodName;

        protected ABCEndpointFilters(ILoggerFactory loggerFactory)
        {
            Logger = loggerFactory.CreateLogger<ABCEndpointFilters>();
            _methodName = GetType().Name;
        }

        public virtual async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context,
            EndpointFilterDelegate next)
        {
            Logger.LogInformation("{MethodName} Before next", _methodName);
            var result = await next(context);
            Logger.LogInformation("{MethodName} After next", _methodName);
            return result;
        }
    }

    class AEndpointFilter : ABCEndpointFilters
    {
        public AEndpointFilter(ILoggerFactory loggerFactory)
            : base(loggerFactory)
        {
        }

        [Inject]
        public CreateOrderCommandValidator Validations { get; }

        public override async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context,
            EndpointFilterDelegate next)
        {
            var validationResult = await Validations.ValidateAsync(context.HttpContext.Request as CreateOrderCommand);
            //var tdparam = efiContext.GetArgument<Todo>(0);

            if (!string.IsNullOrEmpty(validationResult))
            {
                return Results.Problem(validationError);
            }
            return await next(context);


            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
        }
    }
}
