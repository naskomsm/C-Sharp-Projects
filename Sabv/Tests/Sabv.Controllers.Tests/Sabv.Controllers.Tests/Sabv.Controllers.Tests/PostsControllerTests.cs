namespace Sabv.Controllers.Tests
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using Sabv.Common;
    using Sabv.Data.Models;
    using Sabv.Services.Data;
    using Sabv.Web.Controllers;
    using Sabv.Web.ViewModels.Comments;
    using Sabv.Web.ViewModels.Posts;
    using Xunit;


    public class PostsControllerTests
    {
        [Fact]
        public async Task DetailsShouldWork()
        {
            // Arrange
            var mockCitiesService = new Mock<ICitiesService>();
            var mockMakesService = new Mock<IMakesService>();
            var mockCategoriesService = new Mock<ICategoriesService>();
            var mockModelsService = new Mock<IModelsService>();
            var mockVehicleCategoriesService = new Mock<IVehicleCategoriesService>();
            var mockColorsService = new Mock<IColorService>();
            var mockJsonsService = new Mock<IJsonService>();
            var mockCloudinaryService = new Mock<ICloudinaryService>();

            var mockUserManager = this.GetMockUserManager();
            var mockCommentsService = new Mock<ICommentsService>();
            var mockPostsService = new Mock<IPostsService>();

            mockCommentsService
               .Setup(mc => mc.GetAll())
               .Returns(this.GetAllComments());

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
                .Returns(Task.FromResult(new ApplicationUser() { UserName = "MyName@abv.bg", Image = new Image() { Url = GlobalConstants.BaseCloudinaryLink + "testUrl" } }));

            // Act
            var controller = new PostsController(
                mockPostsService.Object,
                mockCitiesService.Object,
                mockCategoriesService.Object,
                mockMakesService.Object,
                mockModelsService.Object,
                mockVehicleCategoriesService.Object,
                mockColorsService.Object,
                mockJsonsService.Object,
                mockUserManager.Object,
                mockCloudinaryService.Object,
                mockCommentsService.Object);

            // Assert
            var result = await controller.Details(1);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<PostDetailsAndCommentsViewModel>(viewResult.ViewData.Model);
            Assert.Null(model.PostDetails);
            Assert.NotNull(model.CommentViewModel);
            Assert.Single(model.CommentViewModel.Comments);
            Assert.Equal(1, model.CommentViewModel.PostId);
            Assert.Equal("MyName@abv.bg", model.CommentViewModel.User.UserName);
        }

        private Mock<UserManager<ApplicationUser>> GetMockUserManager()
        {
            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            return new Mock<UserManager<ApplicationUser>>(
                userStoreMock.Object, null, null, null, null, null, null, null, null);
        }

        private IEnumerable<Comment> GetAllComments()
        {
            return new List<Comment>()
            {
                new Comment() { Id = 1, PostId = 1 },
                new Comment() { Id = 2, PostId = 2 },
                new Comment() { Id = 3, PostId = 3 },
            };
        }
    }
}
