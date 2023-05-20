using Ilk_MVC_Proyekt.Entites;

namespace Ilk_MVC_Proyekt.Services
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
        Category GetCategory(int id);
        void AddCategory(Category category);
        void RemoveCategory(int id);
        void EditCategory(Category category);
        List<Category> SearchCategories(string text);
    }
}
