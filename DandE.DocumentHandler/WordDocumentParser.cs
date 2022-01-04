namespace DandE.DocumentHandler
{
    using DocumentFormat.OpenXml.Packaging;

    internal class WordDocumentParser : DocumentParser
    {
        public override ParseResult ParseDocument(byte[] bytes)
        {
            var document = WordprocessingDocument.Open(WriteBytesToTempFile(bytes), false);

            return new ParseResult
            {
                Text = document.MainDocumentPart.Document.InnerText
            };
        }

        private string WriteBytesToTempFile(byte[] bytes)
        {
            var filePath = Path.GetTempFileName();

            File.WriteAllBytes(filePath, bytes);

            return filePath;
        }
    }
}