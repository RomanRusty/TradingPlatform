using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace TradingPlatform.Infrastructure
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RequestValidationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestValidationMiddleware> _logger;
        public RequestValidationMiddleware(RequestDelegate next, ILogger<RequestValidationMiddleware> logger)
        {
            _next = next;
            _logger= logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (System.Exception e)
            {
                _logger.LogError(e, e.Message);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RequestValidationMiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestValidationMiddleware>();
        }
    }
}
