
namespace DanE.Web.Controllers
{
    [Serializable]
    public class ChatTimeoutException : Exception
    {
        public ChatTimeoutException()
        {
        }

        public ChatTimeoutException(string? message) : base(message)
        {
        }

        public ChatTimeoutException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}