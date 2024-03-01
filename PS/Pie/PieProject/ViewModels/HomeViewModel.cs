using PieProject.Models;

namespace PieProject.ViewModels;

public class HomeViewModel
{
    public required IEnumerable<Pie> PiesOfTheWeek { get; set; }
}
