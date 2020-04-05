namespace Sabv.Controllers.Tests
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using Sabv.Data.Models;
    using Sabv.Services.Data;
    using Sabv.Web.Areas.Administration.Controllers;
    using Sabv.Web.ViewModels.Chat;
    using Xunit;

    public class ChatControllerAdministrationTests : BaseClass
    {
        [Fact]
        public void IndexShouldReturnProperView()
        {
            // Arrange
            var mockMessagesService = new Mock<IMessagesService>();
            mockMessagesService.Setup(mm => mm.GetAll()).Returns(this.GetAll<Message>());

            var controller = new ChatController(mockMessagesService.Object);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<MessagesAdminPanel>(viewResult.ViewData.Model);
        }

        [Fact]
        public async Task DeleteShouldReturnProperRedirect()
        {
            // Arrange
            var mockMessagesService = new Mock<IMessagesService>();
            var controller = new ChatController(mockMessagesService.Object);

            // Act
            var result = await controller.Delete(0);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }
    }
}
