namespace DandE.DocumentHandler
{
    public abstract class Card
    {
        public Card(byte[] bytes)
        {
            this.Bytes = bytes;

            this.Text = this.Parser.ParseDocument(bytes).Text;
        }

        public abstract DocumentParser Parser { get; }

        public string Text { get; set; }

        public byte[] Bytes { get; set; }

        public string Title { get; set; }
    }
}