using Ilk_MVC_Proyekt.Context;
using Ilk_MVC_Proyekt.Entites;
using Ilk_MVC_Proyekt.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ilk_MVC_Proyekt.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            ViewBag.Categories = _categoryService.GetCategories();
            return View();
        }
        public IActionResult Update(int id)
        {
            var category = _categoryService.GetCategory(id);
            ViewBag.Category = category;

            return View();
        }
        public IActionResult AddCategory(IFormFile image, string categoryName)
        {
            var category = new Category();
            category.CategoryName = categoryName;

            if (image != null)
            {
                string filename = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + Path.GetExtension(image.FileName);
                using (Stream stream = new FileStream("wwwroot/images/" + filename, FileMode.Create))
                {
                    image.CopyTo(stream);
                }
                category.ImageUrl = "~/images/" + filename;
            }

            _categoryService.AddCategory(category);

            return RedirectToAction("Index");
        }
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.RemoveCategory(id);

            return RedirectToAction("Index");
        }
        public IActionResult UpdateCategory(IFormFile image, int id, string name)
        {
            var category = new Category();
            category.CategoryId = id;
            category.CategoryName = name;

            if (image != null)
            {
                string filename = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + Path.GetExtension(image.FileName);
                using (Stream stream = new FileStream("wwwroot/images/" + filename, FileMode.Create))
                {
                    image.CopyTo(stream);
                }
                category.ImageUrl = "~/images/" + filename;
            }

            _categoryService.EditCategory(category);
            return RedirectToAction("Index");
        }
        public IActionResult SearchCategories(string text)
        {
            ViewBag.Categories = _categoryService.SearchCategories(text);
            return View("Index");
        }
    }
}
