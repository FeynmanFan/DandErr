namespace DandE.DocumentHandler
{
    using Microsoft.Extensions.Logging;

    public abstract class Card
    {
        private const int AccessDenied = -1;

        public Card(byte[] bytes)
        {
            var parseResult = this.Parser.ParseDocument(bytes);
            this.Text = parseResult?.Text ?? string.Empty;
            this.Title = parseResult?.Title ?? string.Empty;
            this.Bytes = bytes;
        }

        public abstract DocumentParser Parser { get; }

        public string Text { 
            get
            {
                return "This is wrong";
            }
            set;
        }

        public byte[] Bytes { get; set; }

        public string Title { get; set; }

        public static bool DocumentIsPermittedForCurrentUser(string currentUser, string documentFileName)
        {
            // For demonstration purposes, all documents are permitted.
            return File.OpenRead(documentFileName).ReadByte() != AccessDenied;
        }
    }
}