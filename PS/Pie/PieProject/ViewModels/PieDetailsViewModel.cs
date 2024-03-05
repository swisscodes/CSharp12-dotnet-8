using PieProject.Models;

namespace PieProject.ViewModels;

public class PieDetailsViewModel()
{
    public required Pie? Pie { get; init; }
    public string? CurrentCategory { get; init; }
}