namespace Sabv.Controllers.Tests
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading;
    using System.Threading.Tasks;

    using cloudscribe.Pagination.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using Sabv.Common;
    using Sabv.Data.Models;
    using Sabv.Services.Data;
    using Sabv.Web.Controllers;
    using Sabv.Web.ViewModels.Models;
    using Sabv.Web.ViewModels.Posts;
    using Xunit;

    public class PostsControllerTests : BaseClass
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
                .Returns(Task.FromResult(new ApplicationUser() { UserName = "MyName", Image = new Image() { Url = "testUrl" } }));

            // Act
            var controller = new PostsController(
                mockPostsService.Object,
                mockCitiesService.Object,
                mockCategoriesService.Object,
                mockMakesService.Object,
                mockModelsService.Object,
                mockVehicleCategoriesService.Object,
                mockColorsService.Object,
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
            Assert.Equal("MyName", model.CommentViewModel.User.UserName);
        }

        [Fact]
        public void AllModelsShoudWork()
        {
            // Arrange
            var mockCitiesService = new Mock<ICitiesService>();
            var mockMakesService = new Mock<IMakesService>();
            var mockCategoriesService = new Mock<ICategoriesService>();
            var mockCommentsService = new Mock<ICommentsService>();
            var mockVehicleCategoriesService = new Mock<IVehicleCategoriesService>();
            var mockColorsService = new Mock<IColorService>();
            var mockCloudinaryService = new Mock<ICloudinaryService>();

            var mockUserManager = this.GetMockUserManager();
            var mockModelsService = new Mock<IModelsService>();
            var mockPostsService = new Mock<IPostsService>();

            mockModelsService
               .Setup(mc => mc.GetAll<ModelsReturnModel>())
               .Returns(this.GetAll<ModelsReturnModel>());

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
                .Returns(Task.FromResult(new ApplicationUser() { UserName = "MyName@abv.bg", Image = new Image() { Url = "testUrl" } }));

            // Act
            var controller = new PostsController(
                mockPostsService.Object,
                mockCitiesService.Object,
                mockCategoriesService.Object,
                mockMakesService.Object,
                mockModelsService.Object,
                mockVehicleCategoriesService.Object,
                mockColorsService.Object,
                mockUserManager.Object,
                mockCloudinaryService.Object,
                mockCommentsService.Object);

            // Assert
            var result = controller.AllModels();

            var typeResult = Assert.IsType<ActionResult<ICollection<ModelsReturnModel>>>(result);
            Assert.Equal(3, typeResult.Value.Count);
        }

        [Fact]
        public void SearchShouldWork()
        {
            // Arrange
            var mockCitiesService = new Mock<ICitiesService>();
            var mockMakesService = new Mock<IMakesService>();
            var mockCategoriesService = new Mock<ICategoriesService>();
            var mockModelsService = new Mock<IModelsService>();
            var mockVehicleCategoriesService = new Mock<IVehicleCategoriesService>();
            var mockColorsService = new Mock<IColorService>();
            var mockCloudinaryService = new Mock<ICloudinaryService>();
            var mockCommentsService = new Mock<ICommentsService>();
            var mockPostsService = new Mock<IPostsService>();

            var mockUserManager = this.GetMockUserManager();

            mockCategoriesService
                .Setup(mc => mc.GetAll<Category>())
                .Returns(this.GetAll<Category>());

            mockCitiesService
                .Setup(mc => mc.GetAll<City>())
                .Returns(this.GetAll<City>());

            mockColorsService
                .Setup(mc => mc.GetAll<Color>())
                .Returns(this.GetAll<Color>());

            mockMakesService
                .Setup(mc => mc.GetAll<Make>())
                .Returns(this.GetAll<Make>());

            mockVehicleCategoriesService
                .Setup(mc => mc.GetAll<VehicleCategory>())
                .Returns(this.GetAll<VehicleCategory>());

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

            // Act
            var controller = new PostsController(
                mockPostsService.Object,
                mockCitiesService.Object,
                mockCategoriesService.Object,
                mockMakesService.Object,
                mockModelsService.Object,
                mockVehicleCategoriesService.Object,
                mockColorsService.Object,
                mockUserManager.Object,
                mockCloudinaryService.Object,
                mockCommentsService.Object);

            // Assert
            var result = controller.Search();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<SearchViewModel>(viewResult.ViewData.Model);
            Assert.Equal(4, model.Categories.Count());
            Assert.Equal(4, model.Cities.Count());
            Assert.Equal(4, model.Colors.Count());
            Assert.Equal(4, model.Makes.Count());
            Assert.Equal(4, model.VehicleCategories.Count());
        }

        [Fact]
        public void AllShouldWork()
        {
            // Arrange
            var mockCitiesService = new Mock<ICitiesService>();
            var mockMakesService = new Mock<IMakesService>();
            var mockCategoriesService = new Mock<ICategoriesService>();
            var mockModelsService = new Mock<IModelsService>();
            var mockVehicleCategoriesService = new Mock<IVehicleCategoriesService>();
            var mockColorsService = new Mock<IColorService>();
            var mockCloudinaryService = new Mock<ICloudinaryService>();
            var mockCommentsService = new Mock<ICommentsService>();
            var mockPostsService = new Mock<IPostsService>();

            var mockUserManager = this.GetMockUserManager();

            var inputModel = new PostDetailsInputModel()
            {
                Color = "Blue",
                Condition = "Used",
                Currency = "LV",
                EngineType = "Disel",
                Eurostandard = 5,
                Make = 11,
                Model = "M5",
            };

            mockPostsService
                .Setup(mp => mp.Filter(inputModel))
                .Returns(this.GetAll<Post>());

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
                .Returns(Task.FromResult(new ApplicationUser() { UserName = "MyName@abv.bg", Image = new Image() { Url = "testUrl" } }));

            // Act
            var controller = new PostsController(
                mockPostsService.Object,
                mockCitiesService.Object,
                mockCategoriesService.Object,
                mockMakesService.Object,
                mockModelsService.Object,
                mockVehicleCategoriesService.Object,
                mockColorsService.Object,
                mockUserManager.Object,
                mockCloudinaryService.Object,
                mockCommentsService.Object);

            // Assert
            var result = controller.All(inputModel);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<PagedResult<AllPagePostViewModel>>(viewResult.ViewData.Model);
            Assert.NotEmpty(model.Data);
            Assert.Equal(3, model.Data.Count());
            Assert.Equal(3, model.TotalItems);
            Assert.Equal(1, model.PageNumber);
            Assert.Equal(5, model.PageSize);
        }

        [Fact]
        public void CreateGetShouldWork()
        {
            // Arrange
            var mockCitiesService = new Mock<ICitiesService>();
            var mockMakesService = new Mock<IMakesService>();
            var mockCategoriesService = new Mock<ICategoriesService>();
            var mockModelsService = new Mock<IModelsService>();
            var mockVehicleCategoriesService = new Mock<IVehicleCategoriesService>();
            var mockColorsService = new Mock<IColorService>();
            var mockCloudinaryService = new Mock<ICloudinaryService>();
            var mockCommentsService = new Mock<ICommentsService>();
            var mockPostsService = new Mock<IPostsService>();

            var mockUserManager = this.GetMockUserManager();

            mockCategoriesService
                .Setup(mc => mc.GetAll<Category>())
                .Returns(this.GetAll<Category>());

            mockCitiesService
                .Setup(mc => mc.GetAll<City>())
                .Returns(this.GetAll<City>());

            mockColorsService
                .Setup(mc => mc.GetAll<Color>())
                .Returns(this.GetAll<Color>());

            mockMakesService
                .Setup(mc => mc.GetAll<Make>())
                .Returns(this.GetAll<Make>());

            mockVehicleCategoriesService
                .Setup(mc => mc.GetAll<VehicleCategory>())
                .Returns(this.GetAll<VehicleCategory>());

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

            // Act
            var controller = new PostsController(
                mockPostsService.Object,
                mockCitiesService.Object,
                mockCategoriesService.Object,
                mockMakesService.Object,
                mockModelsService.Object,
                mockVehicleCategoriesService.Object,
                mockColorsService.Object,
                mockUserManager.Object,
                mockCloudinaryService.Object,
                mockCommentsService.Object);

            // Assert
            var result = controller.Create();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<CreatePageViewModel>(viewResult.ViewData.Model);
            Assert.Equal(3, model.Categories.Count());
            Assert.Equal(3, model.Cities.Count());
            Assert.Equal(3, model.Colors.Count());
            Assert.Equal(3, model.Makes.Count());
            Assert.Equal(3, model.VehicleCategories.Count());
        }

        [Fact]
        public async Task CreatePostShouldWork()
        {
            // Arrange
            var mockCitiesService = new Mock<ICitiesService>();
            var mockMakesService = new Mock<IMakesService>();
            var mockCategoriesService = new Mock<ICategoriesService>();
            var mockModelsService = new Mock<IModelsService>();
            var mockVehicleCategoriesService = new Mock<IVehicleCategoriesService>();
            var mockColorsService = new Mock<IColorService>();
            var mockCloudinaryService = new Mock<ICloudinaryService>();
            var mockCommentsService = new Mock<ICommentsService>();
            var mockPostsService = new Mock<IPostsService>();

            var mockUserManager = this.GetMockUserManager();

            mockCategoriesService
                .Setup(mc => mc.GetCategoryByName("Cars and jeeps"))
                .Returns(new Category() { Id = 1, Name = "Cars and jeeps" });

            mockCitiesService
                .Setup(mc => mc.GetCityByName("Sofia"))
                .Returns(new City() { Id = 1, Name = "Sofia" });

            mockColorsService
                .Setup(mc => mc.GetColorByName("Blue"))
                .Returns(new Color() { Id = 1, Name = "Blue" });

            mockMakesService
                .Setup(mc => mc.GetMakeById(11))
                .Returns(new Make() { Id = 11, Name = "BMW" });

            mockModelsService
                .Setup(mc => mc.GetModelByName("M5"))
                .Returns(new Model() { Id = 1, Name = "M5" });

            mockVehicleCategoriesService
                .Setup(mc => mc.GetVehicleCategoryByName("Sedan"))
                .Returns(new VehicleCategory() { Id = 1, Name = "Sedan" });

            var files = new List<IFormFile>();
            using (var stream = File.OpenRead("../../../Files/cat.jpg"))
            {
                FormFile file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                {
                    Headers = new HeaderDictionary(),
                    ContentType = "image/jpeg",
                };

                files.Add(file);
            }

            mockCloudinaryService
                .Setup(mc => mc.UploadAsync(files))
                .Returns(Task.FromResult(this.GetAll<Image>()));

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

            // Act
            var controller = new PostsController(
                mockPostsService.Object,
                mockCitiesService.Object,
                mockCategoriesService.Object,
                mockMakesService.Object,
                mockModelsService.Object,
                mockVehicleCategoriesService.Object,
                mockColorsService.Object,
                mockUserManager.Object,
                mockCloudinaryService.Object,
                mockCommentsService.Object);

            // Assert
            var inputModel = new CreatePageInputModel()
            {
                PostCategory = "Cars and jeeps",
                Town = "Sofia",
                Color = "Blue",
                Make = 11,
                Model = "M5",
                VehicleCategory = "Sedan",
                Condition = "Used",
                Currency = "LV",
                EngineType = "Disel",
                TransmissionType = "Automatic",
                Eurostandard = 5,
                Description = "some random description",
                Horsepower = 155,
                Email = "randomEmail@gmail.com",
                Year = 2020,
                Mileage = 152456,
                Modification = "F10",
                Price = 52000,
                PhoneNumber = "0897132123",
                Files = files,
            };

            // Act
            var result = await controller.Create(inputModel);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Posts", redirectToActionResult.ControllerName);
            Assert.Equal("Details", redirectToActionResult.ActionName);
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
