using Microsoft.AspNetCore.Mvc;
using PieProject.Models;
using PieProject.Models.Repository;
using PieProject.ViewModels;

namespace PieProject.Controllers;
public class PieController(IPieRepo pieRepo) : Controller
{
    public IActionResult List(string category)
    {
        IEnumerable<Pie> pies;
        string currentCategory = category;
        if (string.IsNullOrEmpty(category))
        {
            pies = pieRepo.AllPies.OrderBy(p => p.PieId);
            currentCategory = "All pies";
        }
        else
        {
            pies = pieRepo.AllPies.Where(c => c.Category.CategoryName == category)
                .OrderBy(p => p.PieId);
        }

        PieListViewModel pieDetailsViewModel = new()
        {
            Pies = pies,
            CurrentCategory = currentCategory
        };

        return View(pieDetailsViewModel);
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
