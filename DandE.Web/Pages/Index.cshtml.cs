namespace WebApplication1.Pages
{
    using DandE.DocumentHandler;
    using DocumentFormat.OpenXml.Packaging;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System.Reflection;
    using System.IO.Packaging;

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

                var documentCollection = new List<WordDocumentCard>();

                foreach (var document in documents)
                {
                    var wordDoc = WordprocessingDocument.Open(document, false);

                    var doc = new WordDocumentCard
                    {
                        Text = wordDoc.MainDocumentPart.Document.InnerText,
                        Title = wordDoc.PackageProperties.Title
                    };

                    documentCollection.Add(doc);
                }

                return documentCollection;
            }
        }
    }
}