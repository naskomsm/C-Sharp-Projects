namespace Sabv.Controllers.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using Sabv.Data.Models;
    using Sabv.Services.Data;
    using Sabv.Services.Messaging;
    using Sabv.Web.Controllers;
    using Sabv.Web.ViewModels.Home;
    using Xunit;

    public class HomeControllerTests
    {
        [Fact]
        public void IndexShouldReturnProperView()
        {
            // Arange
            var mockCategoriesService = new Mock<ICategoriesService>();
            mockCategoriesService.Setup(mc => mc.GetAll()).Returns(this.GetAllCategories());

            var mockImagesService = new Mock<IImagesService>();
            mockImagesService.Setup(mi => mi.GetAll()).Returns(this.GetFirstThreeImages());

            var mockPostsService = new Mock<IPostsService>();
            mockPostsService.Setup(mp => mp.GetAll()).Returns(this.GetFirstSixPosts());

            var mockEmailSender = new Mock<SendGridEmailSender>("12345");

            var controller = new HomeController(
                mockPostsService.Object,
                mockCategoriesService.Object,
                mockImagesService.Object,
                mockEmailSender.Object);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IndexViewModel>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Categories.Count());
            Assert.Equal(6, model.Posts.Count());
            Assert.Equal(3, model.FirstThreeImages.Count());
        }

        [Fact]
        public void AboutShouldReturnProperView()
        {
            // Assert
            var mockCategoriesService = new Mock<ICategoriesService>();
            var mockImagesService = new Mock<IImagesService>();
            var mockPostsService = new Mock<IPostsService>();
            var mockEmailSender = new Mock<SendGridEmailSender>("12345");

            var controller = new HomeController(
                mockPostsService.Object,
                mockCategoriesService.Object,
                mockImagesService.Object,
                mockEmailSender.Object);

            // Act
            var result = controller.About();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void ChatViewShouldReturnProperView()
        {
            // Assert
            var mockCategoriesService = new Mock<ICategoriesService>();
            var mockImagesService = new Mock<IImagesService>();
            var mockPostsService = new Mock<IPostsService>();
            var mockEmailSender = new Mock<SendGridEmailSender>("12345");

            var controller = new HomeController(
                mockPostsService.Object,
                mockCategoriesService.Object,
                mockImagesService.Object,
                mockEmailSender.Object);

            // Act
            var result = controller.ChatView();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task SendEmailShouldWork()
        {
            // Assert
            var mockCategoriesService = new Mock<ICategoriesService>();
            var mockImagesService = new Mock<IImagesService>();
            var mockPostsService = new Mock<IPostsService>();
            var mockEmailSender = new Mock<IEmailSender>();

            var inputModel = new EmailContactInputModel()
            {
                From = "gosho123@abv.bg",
                FromName = "goshkoBRAT",
                Message = "gosho sum az",
                Subject = "za mene staa vupros",
            };

            var controller = new HomeController(
                mockPostsService.Object,
                mockCategoriesService.Object,
                mockImagesService.Object,
                mockEmailSender.Object);

            // Act
            var result = await controller.SendEmailAsync(inputModel);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Home", redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        private IEnumerable<Category> GetAllCategories()
        {
            return new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Cars and jeeps",
                    Description = "category1",
                },
                new Category()
                {
                    Id = 2,
                    Name = "Buses",
                    Description = "category2",
                },
            };
        }

        private IEnumerable<Image> GetFirstThreeImages()
        {
            return new List<Image>()
            {
                new Image()
                {
                    Id = 1,
                    Url = "url1",
                },
                new Image()
                {
                    Id = 2,
                    Url = "url2",
                },
                new Image()
                {
                    Id = 3,
                    Url = "url3",
                },
            };
        }

        private IEnumerable<Post> GetFirstSixPosts()
        {
            return new List<Post>()
            {
                new Post()
                {
                    Id = 1,
                },
                new Post()
                {
                    Id = 2,
                },
                new Post()
                {
                    Id = 3,
                },
                new Post()
                {
                    Id = 4,
                },
                new Post()
                {
                    Id = 5,
                },
                new Post()
                {
                    Id = 6,
                },
            };
        }
    }
}
