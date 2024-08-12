using Ordering.Domain.AggregatesModel.BuyerAggregate;
using System.Text.Json;

namespace Ordering.API.Middlewares
{
    public class RequestResponseLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly bool _isRequestResponseLoggingEnabled;
        private readonly IServiceProvider _serviceProvider;

        public RequestResponseLoggerMiddleware(
            RequestDelegate next, 
            IConfiguration config,
            IServiceProvider serviceProvider)
        {
            _next = next;
            _isRequestResponseLoggingEnabled = config.GetValue("EnableRequestResponseLogging", false);
            _serviceProvider = serviceProvider;
        }

        public async Task InvokeAsync(HttpContext httpContext, IBuyerRepository dbContext)
        {
            if (_isRequestResponseLoggingEnabled)
            {
                // wip body to middle class 
                // https://learn.microsoft.com/en-us/answers/questions/1109851/asp-net-core-web-api-how-to-log-requests-and-respo
                var request = JsonSerializer.Serialize(HttpContextUtility.ToJsonData(httpContext.Request, httpContext));
                var correlationId = Guid.NewGuid();
                var saveTime = DateTimeOffset.UtcNow;

                using (var scope = _serviceProvider.CreateScope())
                {
                    var requestRepository = scope.ServiceProvider.GetRequiredService<IRequestRepository>();
                    requestRepository.Add(new BuildingBlocks.Domain.Request.Request()
                    {
                        Content = request,
                        CorrelationId = correlationId,
                        ExecutionTime = saveTime
                    });

                    await requestRepository.UnitOfWork.SaveChangesAsync();
                }

                await _next(httpContext);

                // wip body to middle class 
                var response = JsonSerializer.Serialize(HttpContextUtility.ToJsonData(httpContext.Response, httpContext));
                var saveTime2 = DateTimeOffset.UtcNow;

                using (var scope = _serviceProvider.CreateScope())
                {
                    var responseRepository = scope.ServiceProvider.GetRequiredService<IResponseRepository>();
                    responseRepository.Add(new BuildingBlocks.Domain.Response.Response()
                    {
                        Content = response,
                        CorrelationId = correlationId,
                        ExecutionTime = saveTime2
                    });

                    await responseRepository.UnitOfWork.SaveChangesAsync();
                }
            }
            else
            {
                await _next(httpContext);
            }
        }

        private static string FormatHeaders(IHeaderDictionary headers) => string.Join(", ", headers.Select(kvp => $"{kvp.Key}: {string.Join(", ", kvp.Value)}}}"));

        private static async Task<string> ReadBodyFromRequest(HttpRequest request)
        {
            // Ensure the request's body can be read multiple times (for the next middlewares in the pipeline).  
            request.EnableBuffering();

            using var streamReader = new StreamReader(request.Body, leaveOpen: true);
            var requestBody = await streamReader.ReadToEndAsync();

            // Reset the request's body stream position for next middleware in the pipeline.  
            request.Body.Position = 0;
            return requestBody;
        }
    }
}
