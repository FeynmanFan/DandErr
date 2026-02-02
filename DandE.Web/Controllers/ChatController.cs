namespace DanE.Web.Controllers
{
    using DandE.Chat;
    using Microsoft.AspNetCore.Mvc;

    public class ChatController : Controller
    {
        ILogger<ChatController> logger;

        public ChatController(ILogger<ChatController> logger) 
        {
            this.logger = logger;
        }

        public IActionResult Index()
        {
            //try
            //{
                var chatClient = new ChatClient();

                chatClient.Connect();
            //}
            //catch(ChatTimeoutException ex)
            //{
            //    // Log exception details here
            //    this.logger.LogError(ex, "Chat timeout occurred while trying to connect.");

            //    //Console.WriteLine($"Chat timeout occurred: {ex.Message}");
            //    //// Optionally, you can set a user-friendly message to display in the view
            //    //ViewBag.ErrorMessage = "The chat service is currently unavailable. Please try again later.";

            //    // return RedirectToAction("Error", "Chat");
            //    return RedirectToAction("Chat", "Error");
            //}

            return View();
        }

        public IActionResult Error()
        {
            return View("Error");
        }
    }
}
