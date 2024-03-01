using Microsoft.AspNetCore.Mvc;
using PieProject.Models.Repository;
using PieProject.ViewModels;

namespace PieProject.Controllers;

public class HomeController(IPieRepo context) : Controller
{
    public IActionResult Index()
    {
        HomeViewModel homeModel = new()
        {
            PiesOfTheWeek = context.AllPies.Where(p => p.IsPieOfTheWeek)
        };

        return View(homeModel);
    }
}
