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

                var cards = new List<WordDocumentCard>();

                foreach (var document in documents)
                {
                    cards.Add(new WordDocumentCard(document));
                }

                return cards;
            }
        }

        private string[] GetDocumentFiles()
        {
            var rootPath = this.environment.WebRootPath;

            var docPath = Path.Combine(rootPath, "../documents");

            var documents = Directory.GetFiles(docPath, "*.docx");

            string CurrentUser = "TestUser";

            return [.. documents.Where(fileName => Card.DocumentIsPermittedForCurrentUser(CurrentUser, fileName))];
        }
    }
}