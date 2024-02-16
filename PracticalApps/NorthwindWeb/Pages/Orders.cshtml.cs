using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthwindModel;

namespace NorthwindWeb.Pages
{
    public class OrdersModel(NorthwindContext db) : PageModel
    {
        public int OrdersCount { get; set; }
        public void OnGet()
        {
            ViewData["title"] = "Orders";
            OrdersCount = db.Orders.Count();
        }
    }
}
