using PieProject.Models.Repository;

namespace PieProject.Models.Mock;

public class MockCategoryRepo : ICategoryRepo
{
    public IEnumerable<Category> AllCategories =>
        [

            new() {CategoryId=1, CategoryName="Fruit pies", Description="All-fruity pies" },
            new() {CategoryId=2, CategoryName="Cheese cakes", Description="Cheesy all the way" },
            new() {CategoryId=3, CategoryName="Seasonal pies", Description="Get in the mood for a seasonal pie" },

        ];

}
