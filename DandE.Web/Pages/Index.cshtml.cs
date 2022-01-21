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
                string[] documents = GetDocumentFiles();

                var cards = new List<WordDocumentCard>();  

                foreach(var document in documents)
                {
                    logger.LogInformation($"Creating card for '{document}'");

                    cards.Add(new WordDocumentCard(document, logger));
                }

                return cards;
            }
        }

        // For the learner reading this later on: this should be injected just like the logger is up top
        public object CurrentUser { get; private set; }

        private string[] GetDocumentFiles()
        {
            logger.LogDebug("Enter get document files");

            var rootPath = this.environment.WebRootPath;

            var docPath = Path.Combine(rootPath, "../documents");

            var documents = Directory.GetFiles(docPath, "*.docx");

            logger.LogDebug("Returning document list");

            return documents.Where(fileName => Card.DocumentIsPermittedForCurrentUser(CurrentUser, fileName, logger)).ToArray();
        }
    }
}