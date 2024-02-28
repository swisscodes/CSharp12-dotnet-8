using Microsoft.AspNetCore.Mvc;
using PieProject.Models.Repository;
using PieProject.ViewModels;

namespace PieProject.Controllers;
public class PieController(IPieRepo pieRepo, ICategoryRepo categoryRepo) : Controller
{
    public IActionResult List()
    {
        PieListViewModel pieListViewModel = new(pieRepo.AllPies, "Cheese cake");
        return View(pieListViewModel);
    }
}
