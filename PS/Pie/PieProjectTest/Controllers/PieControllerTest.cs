using BethanysPieShopTests.Mocks;
using Microsoft.AspNetCore.Mvc;
using PieProject.Controllers;
using PieProject.ViewModels;

namespace PieProjectTest.Controllers;
public class PieControllerTest
{
    [Fact]
    public void List_EmptyCategory_ReturnAllPies()
    {
        //Arrange
        var mockPieRepo = RepositoryMocks.GetPieRepository();
        var mockCategoryRepo = RepositoryMocks.GetCategoryRepository();
        var pieController = new PieController(mockPieRepo.Object);

        //ACT
        var result = pieController.List("");

        //Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var pieListViewModel = Assert.IsAssignableFrom<PieListViewModel>(viewResult.ViewData.Model);
        Assert.Equal(10, pieListViewModel.Pies.Count());
    }
}
