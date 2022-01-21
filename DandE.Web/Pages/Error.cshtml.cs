using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace WebApplication1.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class ErrorModel : PageModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        private readonly ILogger<ErrorModel> _logger;

        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        public bool ErrorIsIgnorable(HttpContext context, Exception error)
        {
            return new int[] { 404, 303 }.Contains(HttpContext.Response.StatusCode);
        }

        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;

            var exHandler =
            HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if (exHandler != null)
            {
                if (ErrorIsIgnorable(HttpContext, exHandler.Error))
                {
                    return;
                }

                _logger.LogError(exHandler.Error.ToString());

                NotifyDevelopers(exHandler.Error);
            }
        }

        private void NotifyDevelopers(Exception error)
        {
            // email
            // Slack
            // text message
            // database
            // IP over Avian carriers
        }
    }
}