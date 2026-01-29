using DanE.Web.Controllers;

namespace DandE.Chat
{
    public class ChatClient
    {
        public void Connect()
        {
            // Simulate network delay / connection attempt
            throw new ChatTimeoutException("Failed to connect to the chat service within the allotted time (5 seconds).");
        }
    }
}
