using Microsoft.AspNetCore.Mvc;
using PieProject.Models.Repository;
using PieProject.ViewModels;

namespace PieProject.Controllers;
public class PieController(IPieRepo pieRepo) : Controller
{
    public IActionResult List()
    {
        PieListViewModel pieListViewModel = new()
        {
            Pies = pieRepo.AllPies,
            CurrentCategory = "All Pies",
        };

        return View(pieListViewModel);
    }

    public IActionResult Details(int id)
    {
        PieDetailsViewModel pieDetails = new() { Pie = pieRepo.GetPieById(id), CurrentCategory = "Pie details" };
        if (pieDetails.Pie != null)
        {
            return View(pieDetails);
        }

        return NotFound();
    }
}
