using Ilk_MVC_Proyekt.Context;
using Ilk_MVC_Proyekt.Entites;
using static System.Net.Mime.MediaTypeNames;

namespace Ilk_MVC_Proyekt.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ProductContext _context;
        public CategoryService(ProductContext context)
        {
            _context = context;
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void EditCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.FirstOrDefault(cat => cat.CategoryId == id);
        }

        public void RemoveCategory(int id)
        {
            var category = _context.Categories.FirstOrDefault(cat => cat.CategoryId == id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public List<Category> SearchCategories(string text)
        {
            return _context.Categories.Where(c => c.CategoryName.Contains(text)).ToList();
        }
    }
}
