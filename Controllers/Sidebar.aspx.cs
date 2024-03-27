namespace TobaccoWebShop.Controllers
{
    public class Sidebar
    {
        private bool isToggled { get; set; } = false;

        public void ToggleMenu(object sender, EventArgs e)
        {
            isToggled = !isToggled;
            Console.WriteLine(isToggled);

        }
    }
}
