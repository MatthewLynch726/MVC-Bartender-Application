using Microsoft.AspNetCore.Mvc;

namespace MVC_Bartender_Application.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
