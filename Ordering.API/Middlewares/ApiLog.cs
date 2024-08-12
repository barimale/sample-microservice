namespace Ordering.API.Middlewares
{
    public class ApiLog
    {
        public ApiLog()
        {
        }

        public string Headers { get; set; }
        public string AbsoluteUri { get; set; }
        public string Host { get; set; }
        public string RequestBody { get; set; }
        public string UserHostAddress { get; set; }
        public string Useragent { get; set; }
        public string RequestedMethod { get; set; }
        public string StatusCode { get; set; }
    }
}