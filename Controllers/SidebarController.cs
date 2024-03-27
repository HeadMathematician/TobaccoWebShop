using Microsoft.AspNetCore.Mvc;

namespace TobaccoWebShop.Controllers
{
    public class SidebarController : Controller
    {
        private bool isToggled { get; set; } = false;
        public IActionResult Index()
        {
            return View();
        }

        public void ToggleMenu(object sender, EventArgs e)
        {
            isToggled = !isToggled;
            Console.WriteLine(isToggled);

        }
    }
}
