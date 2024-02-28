
namespace PieProject.Models.Repository;

public class CategoryRepo(PieProjectDbContext context) : ICategoryRepo
{
    public IEnumerable<Category> AllCategories => context.Categories.OrderBy(p => p.CategoryName);
}
