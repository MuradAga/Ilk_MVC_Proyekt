using Ilk_MVC_Proyekt.Context;
using Ilk_MVC_Proyekt.Entites;
using Microsoft.AspNetCore.Mvc;

namespace Ilk_MVC_Proyekt.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ProductContext _context;
        public CategoryController(ProductContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }
        public IActionResult Update(int id)
        {
            var category = _context.Categories.FirstOrDefault(cat => cat.CategoryId == id);
            ViewBag.Category = category;

            return View();
        }
        public IActionResult AddCategory(string categoryName)
        {
            var category = new Category()
            {
                CategoryName = categoryName
            };
            _context.Categories.Add(category);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult DeleteCategory(int id)
        {
            var category = _context.Categories.FirstOrDefault(cat => cat.CategoryId == id);
            _context.Categories.Remove(category);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult UpdateCategory(int id, string name)
        {
            var category = new Category()
            {
                CategoryId = id,
                CategoryName = name
            };

            _context.Categories.Update(category);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult SearchCategories(string text)
        {
            ViewBag.Categories = _context.Categories.Where(c => c.CategoryName.Contains(text)).ToList();
            return View("Index");
        }
    }
}
