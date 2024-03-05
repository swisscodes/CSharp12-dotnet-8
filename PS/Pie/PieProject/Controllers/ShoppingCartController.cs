using Microsoft.AspNetCore.Mvc;
using PieProject.Models;
using PieProject.Models.Repository;
using PieProject.ViewModels;

namespace PieProject.Controllers;

public class ShoppingCartController(IPieRepo pieRepo, IShoppingCartRepo shoppingCartRepo) : Controller
{
    public ViewResult Index()
    {
        shoppingCartRepo.ShoppingCartItems = shoppingCartRepo.GetShoppingCartItems();
        ShoppingCartViewModel shoppingCartViewModel = new(shoppingCartRepo.ShoppingCartItems, shoppingCartRepo.GetShoppingCartTotal());
        return View(shoppingCartViewModel);

    }

    public RedirectToActionResult AddToShoppingCart(int pieId)
    {
        Pie? selectedPie = pieRepo.AllPies.FirstOrDefault(p => p.PieId == pieId);
        if (selectedPie != null)
        {
            shoppingCartRepo.AddToCart(selectedPie);
        }
        return RedirectToAction("Index");
    }

}
