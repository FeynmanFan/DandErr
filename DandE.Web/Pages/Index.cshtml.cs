namespace WebApplication1.Pages
{
    using DandE.DocumentHandler;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System.Reflection;

    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> logger;
        IWebHostEnvironment environment;


        public IndexModel(ILogger<IndexModel> _logger, IWebHostEnvironment _environment)
        {
            logger = _logger;
            environment = _environment;
        }

        public void OnGet()
        {

        }
        
        public IEnumerable<WordDocumentCard> Documents
        {
            get
            {
                var rootPath = this.environment.WebRootPath;

                var docPath = Path.Combine(rootPath, "../documents");

                var documents = Directory.GetFiles(docPath, "*.docx");

                return documents.Select(x => new WordDocumentCard(System.IO.File.ReadAllBytes(x)));
            }
        }
    }
}