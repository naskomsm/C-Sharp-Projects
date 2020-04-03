namespace Sabv.Controllers.Tests
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using Sabv.Data.Models;
    using Sabv.Services.Data;
    using Sabv.Web.Areas.Administration.Controllers;
    using Sabv.Web.ViewModels.Comments;
    using Xunit;

    public class CommentsControllerAdministrationTests : BaseClass
    {
        [Fact]
        public void IndexShouldReturnProperView()
        {
            // Arrange
            var mockCommentsService = new Mock<ICommentsService>();
            mockCommentsService.Setup(mm => mm.GetAll()).Returns(this.GetAll<Comment>());

            var controller = new CommentsController(mockCommentsService.Object);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<CommentsAdminPanel>(viewResult.ViewData.Model);
        }

        [Fact]
        public async Task DeleteShouldReturnProperRedirect()
        {
            // Arrange
            var mockCommentsService = new Mock<ICommentsService>();
            var controller = new CommentsController(mockCommentsService.Object);

            // Act
            var result = await controller.Delete(0);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }
    }
}
