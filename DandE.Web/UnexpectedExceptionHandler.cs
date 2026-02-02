namespace DanE.Web
{
    using Microsoft.AspNetCore.Diagnostics;
    using System.Text;

    public class UnexpectedExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<UnexpectedExceptionHandler> _logger;

        public UnexpectedExceptionHandler(ILogger<UnexpectedExceptionHandler> logger)
        {
            this._logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is OperationCanceledException || exception is TaskCanceledException)
            {
                return false;
            }

            var request = httpContext.Request;
            var userName = httpContext.User?.Identity?.IsAuthenticated == true
                ? httpContext.User.Identity.Name
                : "Anonymous";

            var traceId = httpContext.TraceIdentifier;

            string? body = GetBody(request).GetAwaiter().GetResult();

            this._logger.LogError(exception,
                "Unexpected exception occurred. TraceId: {TraceId}, User: {User}, Path: {Path}, Method: {Method}, Body: {Body}",
                traceId,
                userName,
                request.Path,
                request.Method,
                body ?? "<empty>");

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            httpContext.Response.ContentType = "text/html; charset=utf-8";

            var html = "<html><head><title>Unexpected Error</title></head><body>" +
                       "<h1>Unexpected Error</h1>" +
                       "<p>An unexpected error occurred while processing your request.</p>" +
                       "<p>Please try again later or contact support if the problem persists.</p>" +
                       "</body></html>";

            await httpContext.Response.WriteAsync(html, cancellationToken);

            return true;
        }

        /// <summary>
        /// Why isn't this simpler?
        /// </summary>
        /// <param name="request"></param>
        /// <returns>The body of the request</returns>
        public async Task<string?> GetBody(HttpRequest request)
        {
            try
            {
                var buffer = new byte[4096];
                int bytesRead = await request.Body.ReadAsync(buffer);

                if (bytesRead > 0)
                {
                    return Encoding.UTF8.GetString(buffer, 0, bytesRead);
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
