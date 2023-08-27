using Microsoft.AspNetCore.Mvc;
using MVC_Bartender_Application.Data;
using MVC_Bartender_Application.Models;

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
            IEnumerable<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {

            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "The DisplayOrder cannot exactly match the Name");            
            }

            if(ModelState.IsValid) {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(obj);
        }
    }
}

