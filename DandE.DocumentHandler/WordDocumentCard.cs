﻿namespace DandE.DocumentHandler
{
    public class WordDocumentCard : Card
    {
        DocumentParser parser;

        public WordDocumentCard(byte[] bytes) : base(bytes)
        {
        }

        public WordDocumentCard(string filePath) : base()
        {
            try
            {
                var bytes = File.ReadAllBytes(filePath);

                this.Bytes = bytes;
            }
            catch (Exception ex)
            {
            }
        }

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
