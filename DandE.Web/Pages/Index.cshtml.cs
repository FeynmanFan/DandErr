using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
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