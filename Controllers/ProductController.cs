using Microsoft.AspNetCore.Mvc;

namespace TobaccoWebShop.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
