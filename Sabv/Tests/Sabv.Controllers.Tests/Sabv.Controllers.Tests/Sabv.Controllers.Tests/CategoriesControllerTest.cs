namespace Sabv.Controllers.Tests
{
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using Sabv.Data.Models;
    using Sabv.Services.Data;
    using Sabv.Web.Controllers;
    using Sabv.Web.ViewModels.Category;
    using Xunit;

    public class CategoriesControllerTest : BaseClass
    {
        [Fact]
        public void DisplayShouldReturnProperViewWithModel()
        {
            // Assert
            var mockCategoriesService = new Mock<ICategoriesService>();
            mockCategoriesService.Setup(mc => mc.GetCategoryByName("Cars and jeeps"))
                .Returns(new Category() { Name = "Cars and jeeps", Description = "test description", Image = new Image() { Url = "testUrl" } });
            var controller = new CategoriesController(mockCategoriesService.Object);

            // Act
            var result = controller.Display("Cars and jeeps");

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<CategoryViewModel>(viewResult.ViewData.Model);
            Assert.Equal("Cars and jeeps", model.Name);
            Assert.Equal("test description", model.Description);
        }
    }
}
