namespace DandE.DocumentHandler
{
    public class WordDocumentCard : Card
    {
        DocumentParser parser;

        public WordDocumentCard(byte[] bytes) : base(bytes)
        {
        }

        public override DocumentParser Parser
        {
            get
            {
                return this.parser;
            }
        }
    }
}
