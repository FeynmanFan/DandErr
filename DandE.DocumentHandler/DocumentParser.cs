namespace DandE.DocumentHandler
{
    public abstract class DocumentParser
    {
        public abstract ParseResult ParseDocument(byte[] bytes);
    }
}