using Microsoft.AspNetCore.Mvc;
using TobaccoWebShop.Data;
using TobaccoWebShop.Models;

namespace TobaccoWebShop.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }   

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductsIndex()
        {
            return RedirectToAction("Products", "Admin");

        }

        public IActionResult Products()
        {
            List<Product> products = new List<Product>();
            products.AddRange(_context.Products);

            return View(products);
        }

    }

}
