using Microsoft.AspNetCore.Mvc;
using PieProject.Models.Repository;
using PieProject.ViewModels;

namespace PieProject.Controllers;
public class CategoryController(ICategoryRepo categoryRepo) : Controller
{
    public IActionResult Index()
    {
        CategoryListViewModel categoryListView = new(categoryRepo.AllCategories);

        return View();
    }
}
