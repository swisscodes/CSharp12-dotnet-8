using Microsoft.AspNetCore.Mvc;
using PieProject.Models;
using PieProject.Models.Repository;

namespace PieProject.Components;

public class CategoryMenu(ICategoryRepo categoryRepo) : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        IEnumerable<Category> categories = categoryRepo.AllCategories.OrderBy(c => c.CategoryName);
        return View(categories);
    }
}

