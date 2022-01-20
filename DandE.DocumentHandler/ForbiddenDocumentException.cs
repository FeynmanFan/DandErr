namespace DandE.DocumentHandler
{
    public class ForbiddenDocumentException : ApplicationException
    {
        public ForbiddenDocumentException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
