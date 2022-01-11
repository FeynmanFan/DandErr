namespace DandE.DocumentHandler
{
    public abstract class Card
    {
        public Card(byte[] bytes)
        {
            this.Bytes = bytes;

            var result = this.Parser.ParseDocument(bytes);

            this.Text = result.Text;
            this.Title = result.Title;
        }

        public abstract DocumentParser Parser { get; }

        public string Text { get; set; }

        public byte[] Bytes { get; set; }

        public string Title { get; set; }
    }
}