using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PieProject.Models;
using PieProject.Models.Repository;

namespace PieProject.Pages
{
    // we can use this to bind all Properties [BindProperties]
    public class CheckoutModel(IOrderRepo orderRepo, IShoppingCartRepo cart) : PageModel
    {
        [BindProperty]
        public required Order Order { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var items = cart.GetShoppingCartItems();
            if (items.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some pies first");
            }
            if (ModelState.IsValid)
            {
                orderRepo.CreateOrder(Order);
                cart.ClearCart();
                return RedirectToPage("CheckoutComplete");

            }

            return Page();
        }
    }
}
