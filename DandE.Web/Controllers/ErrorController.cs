using Microsoft.AspNetCore.Mvc;

namespace DanE.Web.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Chat()
        {
            return View("Chat");
        }
    }
}
