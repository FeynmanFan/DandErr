using Microsoft.Extensions.Logging;

namespace DandE.DocumentHandler
{
    public class WordDocumentCard : Card
    {
        DocumentParser parser;

        public WordDocumentCard(byte[] bytes, ILogger logger) : base(bytes, logger)
        {
        }

        public WordDocumentCard(string fileName, ILogger logger) : base(File.ReadAllBytes(fileName), logger) { }


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
