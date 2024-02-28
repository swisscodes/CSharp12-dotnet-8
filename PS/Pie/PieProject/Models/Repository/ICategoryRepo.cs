namespace PieProject.Models.Repository;

public interface ICategoryRepo
{
    IEnumerable<Category> AllCategories { get; }
}
