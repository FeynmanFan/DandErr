namespace WebApplication1.Pages
{
    using DandE.DocumentHandler;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class IndexModel : PageModel
    {
        IWebHostEnvironment environment;
        ILogger<IndexModel> logger;

        public IndexModel(ILogger<IndexModel> _logger, IWebHostEnvironment _environment)
        {
            environment = _environment;
            logger = _logger;
        }

        public void OnGet()
        {

        }
        
        public IEnumerable<WordDocumentCard> Documents
        {
            get
            {
                string[] documents = GetDocumentFiles();

                return documents.Select(fileName => new WordDocumentCard(fileName));
            }
        }

        private string[] GetDocumentFiles()
        {
            var rootPath = this.environment.WebRootPath;

            var docPath = Path.Combine(rootPath, "../documents");

            var documents = Directory.GetFiles(docPath, "*.docx");
            return documents;
        }
    }
}