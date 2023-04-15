using AutoMapper;
using Ilk_MVC_Proyekt.Context;
using Ilk_MVC_Proyekt.Entites;
using Ilk_MVC_Proyekt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ilk_MVC_Proyekt.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductContext _context;
        private readonly IMapper _mapper;
        public ProductController(ProductContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }
        public IActionResult AddProduct(ProductAddDTO productModel)
        {
            var product = _mapper.Map<Product>(productModel);
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
