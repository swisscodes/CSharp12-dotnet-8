using Microsoft.AspNetCore.Mvc;

namespace PieProject.Controllers;
public class ContactController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}