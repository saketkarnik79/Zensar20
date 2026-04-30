using System.Diagnostics;
using System.Text.Json;

namespace Web_DemoPagesApp.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Logic that runs before the next middleware goes here
            var stopwatch = Stopwatch.StartNew();

            // Log request details
            var requestInfo = new
            {
                Method = context.Request.Method,
                Path = context.Request.Path,
                QueryString = context.Request.QueryString.ToString(),
                Headers = context.Request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString()),
                Status = context.Response.StatusCode
            };
            Console.WriteLine($"Request: {JsonSerializer.Serialize(requestInfo)}");

            // Call the next middleware in the pipeline
            await _next(context);

            // Logic that runs after the next middleware goes here

            stopwatch.Stop();
            //Console.WriteLine($"Request processed in {stopwatch.ElapsedMilliseconds} ms");
            _logger.LogInformation($"Request processed in {stopwatch.ElapsedMilliseconds} ms");
        }
    }

    public static class RequestLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLoggingMiddleware>();
        }
    }
}
