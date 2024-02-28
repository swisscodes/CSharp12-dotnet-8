using PieProject.Models;

namespace PieProject.ViewModels;

public class PieListViewModel(IEnumerable<Pie> pies, string? currentCategory = null)
{
    public IEnumerable<Pie> Pies { get; init; } = pies;
    public string? CurrentCategory { get; init; } = currentCategory;
}
