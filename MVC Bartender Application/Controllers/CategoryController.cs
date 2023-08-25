using Microsoft.AspNetCore.Mvc;

namespace MVC_Bartender_Application.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
