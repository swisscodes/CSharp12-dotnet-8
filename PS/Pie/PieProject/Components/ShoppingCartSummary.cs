using Microsoft.AspNetCore.Mvc;
using PieProject.Models.Repository;
using PieProject.ViewModels;

namespace PieProject.Components;

public class ShoppingCartSummary(IShoppingCartRepo cartRepo) : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var items = cartRepo.GetShoppingCartItems();
        ShoppingCartViewModel shoppingCartViewModel = new(items, cartRepo.GetShoppingCartTotal());
        return View(shoppingCartViewModel);

    }
}
