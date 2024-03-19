using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PieProject.Pages
{
    public class CheckoutCompeteModel : PageModel
    {
        public void OnGet()
        {
            ViewData["CheckoutCompleteMessage"] = "Thanks for your order.";
        }
    }
}
