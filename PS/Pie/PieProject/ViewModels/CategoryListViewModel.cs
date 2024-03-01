using PieProject.Models;

namespace PieProject.ViewModels;

public class CategoryListViewModel(IEnumerable<Category> category)
{
    public IEnumerable<Category> Categories { get; init; } = category;
}
