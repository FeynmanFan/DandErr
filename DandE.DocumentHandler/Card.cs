namespace DandE.DocumentHandler
{
    using Microsoft.Extensions.Logging;

    public abstract class Card
    {
        public Card(byte[] bytes)
        {
            var parseResult = this.Parser.ParseDocument(bytes);
            this.Text = parseResult?.Text ?? string.Empty;
            this.Title = parseResult?.Title ?? string.Empty;
            this.Bytes = bytes;
        }

        public abstract DocumentParser Parser { get; }

        public string Text { get; set; }

        public byte[] Bytes { get; set; }

        public string Title { get; set; }
    }
}