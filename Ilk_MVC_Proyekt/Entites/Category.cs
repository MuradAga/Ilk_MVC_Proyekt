using System.ComponentModel.DataAnnotations;

namespace Ilk_MVC_Proyekt.Entites
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Product> Products { get; set; }
    }
}
