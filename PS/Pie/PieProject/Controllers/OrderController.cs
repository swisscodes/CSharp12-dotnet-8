using Microsoft.AspNetCore.Mvc;
using PieProject.Models;
using PieProject.Models.Repository;

namespace PieProject.Controllers;
public class OrderController(IOrderRepo orderRepo, IShoppingCartRepo cart) : Controller
{
    public IActionResult Checkout()
    {


        return View();
    }

    [HttpPost]
    public IActionResult Checkout(Order order)
    {
        var items = cart.GetShoppingCartItems();
        if (items.Count == 0)
        {
            ModelState.AddModelError("", "Your cart is empty, add some pies first");
        }
        if (ModelState.IsValid)
        {
            orderRepo.CreateOrder(order);
            cart.ClearCart();
            return RedirectToAction("CheckoutComplete");

        }
        return View(order);
    }

    public IActionResult CheckoutComplete()
    {
        ViewBag.CheckoutCompleteMessage = "Thanks for your order.";
        return View();
    }
}
