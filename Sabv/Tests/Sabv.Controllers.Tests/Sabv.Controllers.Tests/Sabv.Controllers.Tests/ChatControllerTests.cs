namespace Sabv.Controllers.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using Sabv.Data.Models;
    using Sabv.Services.Data;
    using Sabv.Web.Controllers;
    using Sabv.Web.ViewModels.Chat;
    using Xunit;

    public class ChatControllerTests
    {
        [Fact]
        public void MainShouldWorkWithProperView()
        {
            // Arrange
            var mockMessagesService = new Mock<IMessagesService>();
            mockMessagesService.Setup(mm => mm.GetAll()).Returns(this.GetAllMessages());

            var mockUserManager = this.GetMockUserManager();

            var claims = new List<Claim>()
            {
                new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "5247d66a-84ff-4987-abb5-53b1c2e747c2"),
                new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", "naskokolev00@gmail.com"),
                new Claim("AspNet.Identity.SecurityStamp", "E7B2QZV5M4OIRM3ZFIVXFVGR3YULFGO7"),
                new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Admin"),
                new Claim("amr", "pwd"),
            };

            var claimsIdentity = new ClaimsIdentity(claims);

            var principal = new ClaimsPrincipal(claimsIdentity);
            Thread.CurrentPrincipal = principal;

            mockUserManager.Setup(mu => mu.GetUserAsync(principal))
                .Returns(Task.FromResult(new ApplicationUser() { UserName = "MyName", Image = new Image() { Url = "testUrl" } }));

            var controller = new ChatController(mockMessagesService.Object, mockUserManager.Object);

            // Act
            var result = controller.Main();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result.GetAwaiter().GetResult());
            var model = Assert.IsAssignableFrom<ChatViewModel>(viewResult.ViewData.Model);
            Assert.Equal(3, model.Messages.Count());
            Assert.Equal("MyName", model.User.UserName);
        }

        private Mock<UserManager<ApplicationUser>> GetMockUserManager()
        {
            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            return new Mock<UserManager<ApplicationUser>>(
                userStoreMock.Object, null, null, null, null, null, null, null, null);
        }

        private IEnumerable<Message> GetAllMessages()
        {
            return new List<Message>()
            {
                new Message(),
                new Message(),
                new Message(),
            };
        }
    }
}
