using Microsoft.AspNetCore.Http.Extensions;
using System.Text;

namespace Ordering.API.Middlewares
{
    // apilog and responseApiLog with fields according to reqs
    public static class HttpContextUtility
    {
        public static ApiLog ToJsonData(HttpRequest request, HttpContext HttpContext)
        {
            var requestedMethod = request.Method;
            var userHostAddress = request.HttpContext != null ? HttpContext.Request.Host.Value : "0.0.0.0";
            var useragent = request.Headers.UserAgent.ToString();
            var requestMessage = new byte[10];// await request.Body.ReadAsByteArrayAsync();
            var uriAccessed = request.GetDisplayUrl();

            var responseHeadersString = new StringBuilder();
            foreach (var header in request.Headers)
            {
                responseHeadersString.Append($"{header.Key}: {String.Join(", ", header.Value)}{Environment.NewLine}");
            }

            var requestLog = new ApiLog()
            {
                Headers = responseHeadersString.ToString(),
                AbsoluteUri = uriAccessed,
                Host = userHostAddress,
                RequestBody = Encoding.UTF8.GetString(requestMessage),
                UserHostAddress = userHostAddress,
                Useragent = useragent,
                RequestedMethod = requestedMethod.ToString(),
                StatusCode = string.Empty
            };

            return requestLog;
        }

        public static ApiLog ToJsonData(HttpResponse response, HttpContext HttpContext)
        {
            var requestedMethod = string.Empty;
            var userHostAddress = response.HttpContext != null ? HttpContext.Request.Host.Value : "0.0.0.0";
            var useragent = response.Headers.UserAgent.ToString();
            var requestMessage = new byte[10];// await request.Body.ReadAsByteArrayAsync();
            var uriAccessed = string.Empty;

            var responseHeadersString = new StringBuilder();
            foreach (var header in response.Headers)
            {
                responseHeadersString.Append($"{header.Key}: {String.Join(", ", header.Value)}{Environment.NewLine}");
            }

            var responseLog = new ApiLog()
            {
                Headers = responseHeadersString.ToString(),
                AbsoluteUri = uriAccessed,
                Host = userHostAddress,
                RequestBody = Encoding.UTF8.GetString(requestMessage),
                UserHostAddress = userHostAddress,
                Useragent = useragent,
                RequestedMethod = requestedMethod.ToString(),
                StatusCode = string.Empty
            };

            return responseLog;
        }
    }
}
