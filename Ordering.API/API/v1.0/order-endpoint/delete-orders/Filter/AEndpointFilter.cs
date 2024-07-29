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

    public class AEndpointFilter : ABCEndpointFilters
    {
        public AEndpointFilter(ILoggerFactory loggerFactory) : base(loggerFactory) { }
    }
}
