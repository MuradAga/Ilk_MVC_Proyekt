namespace Ilk_MVC_Proyekt.Entites
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public double ProductPrice { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
