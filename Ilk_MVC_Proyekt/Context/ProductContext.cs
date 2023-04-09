using Ilk_MVC_Proyekt.Entites;
using Microsoft.EntityFrameworkCore;

namespace Ilk_MVC_Proyekt.Context
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
