﻿namespace Sabv.Controllers.Tests
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
    using Xunit;

    public class CommentsControllerTests
    {
        [Fact]
        public async Task CreateCommentShouldWork()
        {
            // Arrange
            var mockUserManager = this.GetMockUserManager();
            var mockCommentsService = new Mock<ICommentsService>();
            var mockPostsService = new Mock<IPostsService>();

            mockCommentsService
                .Setup(mc => mc.AddAsync("content", new ApplicationUser(), new Post()))
                .Returns(Task.FromResult(1));

            mockPostsService
                .Setup(mp => mp.GetAll())
                .Returns(this.GetAllPosts());

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

            var controller = new CommentsController(mockUserManager.Object, mockCommentsService.Object, mockPostsService.Object);

            // Act
            var input = new CommentInputModel() { Content = "content", PostId = 1 };
            var result = await controller.Create(input);

            // Assert
            var type = Assert.IsAssignableFrom<ActionResult<CommentResponseModel>>(result);
            Assert.Equal("MyName", result.Value.Username);
            Assert.Equal("content", result.Value.Content);
        }

        [Fact]
        public async Task LikeAsyncShouldWork()
        {
            // Arrange
            var mockUserManager = this.GetMockUserManager();
            var mockCommentsService = new Mock<ICommentsService>();
            var mockPostsService = new Mock<IPostsService>();

            mockCommentsService
                .Setup(mc => mc.Like(1))
                .Returns(Task.CompletedTask);

            var controller = new CommentsController(mockUserManager.Object, mockCommentsService.Object, mockPostsService.Object);

            // Act
            var result = await controller.Like(1);

            // Assert
            var type = Assert.IsType<int>(result);
            Assert.Equal(1, result);
        }

        private Mock<UserManager<ApplicationUser>> GetMockUserManager()
        {
            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            return new Mock<UserManager<ApplicationUser>>(
                userStoreMock.Object, null, null, null, null, null, null, null, null);
        }

        private IEnumerable<Post> GetAllPosts()
        {
            return new List<Post>()
            {
                new Post() { Id = 1 },
                new Post() { Id = 2 },
                new Post() { Id = 3 },
            };
        }
    }
}