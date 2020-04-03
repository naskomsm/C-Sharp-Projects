namespace Sabv.Controllers.Tests
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using Sabv.Data.Models;
    using Sabv.Services.Data;
    using Sabv.Web.Areas.Administration.Controllers;
    using Sabv.Web.ViewModels.Posts;
    using Xunit;

    public class PostsControllerAdministrationTests : BaseClass
    {
        [Fact]
        public void IndexShouldReturnProperView()
        {
            // Arrange
            var mockPostsService = new Mock<IPostsService>();
            mockPostsService.Setup(mm => mm.GetAll()).Returns(this.GetAll<Post>());

            var controller = new PostsController(mockPostsService.Object);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<PostsAdminPanel>(viewResult.ViewData.Model);
        }

        [Fact]
        public async Task DeleteShouldReturnProperRedirect()
        {
            // Arrange
            var mockPostsService = new Mock<IPostsService>();
            var controller = new PostsController(mockPostsService.Object);

            // Act
            var result = await controller.Delete(0);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }
    }
}
