namespace DanE.Web
{
    using DanE.Web.Controllers;
    using Microsoft.AspNetCore.Diagnostics;

    public class ChatTimeoutExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<ChatTimeoutExceptionHandler> _logger;

        public ChatTimeoutExceptionHandler(ILogger<ChatTimeoutExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            if (exception is not ChatTimeoutException timeoutEx)
            {
                return false; 
            }

            _logger.LogError(timeoutEx,"Global handler caught ChatTimeoutException: {Message}. Path: {Path}, Method: {Method}",
                timeoutEx.Message,
                httpContext.Request.Path,
                httpContext.Request.Method);

            httpContext.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
            httpContext.Response.ContentType = "text/html"; 

            await httpContext.Response.WriteAsync("<h1>Chat Service Unavailable</h1>" +
                "<h2>Response from Global Exception Handler</h2>" +
                "<p>The chat service is temporarily down or unreachable. Please try again later.</p>",
                cancellationToken);

            return true; 
        }
    }
}