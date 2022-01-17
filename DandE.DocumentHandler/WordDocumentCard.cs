namespace DandE.DocumentHandler
{
    public class WordDocumentCard : Card
    {
        DocumentParser parser;

        public WordDocumentCard(byte[] bytes) : base(bytes)
        {
        }

        public WordDocumentCard(string fileName) : base(File.ReadAllBytes(fileName)) { }


        public override DocumentParser Parser
        {
            get
            {
                if (this.parser == null)
                {
                    this.parser = new WordDocumentParser();
                }

                return this.parser;
            }
        }
    }
}
