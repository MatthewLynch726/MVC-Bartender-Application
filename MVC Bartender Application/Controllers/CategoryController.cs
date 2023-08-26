using Microsoft.AspNetCore.Mvc;
using MVC_Bartender_Application.Data;

namespace MVC_Bartender_Application.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContex _db;

        public CategoryController(ApplicationDbContex db)
        {
                _db = db;
        }


        public IActionResult Index()
        {
            var objCategoryList = _db.Categories.ToList();

            return View();
        }
    }
}
