namespace Sabv.Controllers.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading;
    using System.Threading.Tasks;

    using AutoMapper;
    using cloudscribe.Pagination.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using Sabv.Data.Models;
    using Sabv.Data.Models.Enums;
    using Sabv.Services.Data;
    using Sabv.Services.Mapping;
    using Sabv.Web.Controllers;
    using Sabv.Web.ViewModels.Favourites;
    using Xunit;

    public class UsersControllerTests : BaseClass
    {
        [Fact]
        public async Task AddFavouriteAsyncShouldWork()
        {
            // Arrange
            var mockUserManager = this.GetMockUserManager();
            var mockFavouritesService = new Mock<IFavouritesService>();

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

            mockFavouritesService
                .Setup(mf => mf.AddAsync(1, "123456"))
                .Returns(Task.CompletedTask);

            var controller = new UsersController(mockUserManager.Object, mockFavouritesService.Object);

            // Act
            var result = await controller.AddFavouriteAsync(1);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Posts", redirectToActionResult.ControllerName);
            Assert.Equal("Details", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task DeleteFavouriteAsyncShouldWork()
        {
            // Arrange
            var mockUserManager = this.GetMockUserManager();
            var mockFavouritesService = new Mock<IFavouritesService>();

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

            mockFavouritesService
                .Setup(mf => mf.Remove(1, "12345"))
                .Returns(Task.CompletedTask);

            var controller = new UsersController(mockUserManager.Object, mockFavouritesService.Object);

            // Act
            var result = await controller.RemoveFavouriteAsync(1);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Users", redirectToActionResult.ControllerName);
            Assert.Equal("Favourites", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task FavouritesAsyncShouldWork()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Post, FavouriteViewModel>();
            });

            var mapper = new Mapper(config);
            mapper.Map(this.GetAllUserFavourites().Select(x => x.Post).FirstOrDefault(), typeof(Post), typeof(FavouriteViewModel));

            AutoMapperConfig.MapperInstance = mapper;

            var mockUserManager = this.GetMockUserManager();
            var mockFavouritesService = new Mock<IFavouritesService>();

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
                .Returns(Task.FromResult(new ApplicationUser() { Id = "123456", UserName = "MyName", Image = new Image() { Url = "testUrl" } }));

            mockFavouritesService
                .Setup(mf => mf.GetAllUserFavourites("123456"))
                .Returns(this.GetAllUserFavourites());

            var controller = new UsersController(mockUserManager.Object, mockFavouritesService.Object);

            // Act
            var result = await controller.Favourites();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<PagedResult<FavouriteViewModel>>(viewResult.ViewData.Model);
            Assert.Single(model.Data);
            Assert.Equal(1, model.TotalItems);
            Assert.Equal(1, model.PageNumber);
            Assert.Equal(15, model.PageSize);
        }

        private IEnumerable<Favourite> GetAllUserFavourites()
        {
            return new List<Favourite>()
            {
                new Favourite()
                {
                    Post = new Post()
                    {
                        Id = 1,

                        Category = new Category()
                        {
                            Id = 1,
                            Name = "Cars and jeeps",
                        },
                        CategoryId = 1,
                        Make = new Make()
                        {
                            Id = 1,
                            Name = "BMW",
                        },
                        MakeId = 1,
                        Model = new Model()
                        {
                            Id = 1,
                            Name = "M5",
                            MakeId = 1,
                            Make = new Make() { Id = 1,  Name = "BMW" },
                        },
                        ModelId = 1,
                        Name = "test name",
                        VehicleCategory = new VehicleCategory()
                        {
                             Id = 1,
                             Name = "Sedan",
                        },
                        VehicleCategoryId = 1,
                        City = new City()
                        {
                            Id = 1,
                            Name = "Sofia",
                        },
                        CityId = 1,
                        PhoneNumber = "0895235689",
                        Color = new Color()
                        {
                            Id = 1,
                            Name = "Black",
                        },
                        ColorId = 1,
                        Email = "random@abv.bg",
                        Price = 155,
                        Mileage = 155555,
                        Horsepower = 1555,
                        User = new ApplicationUser() { Id = "123456", UserName = "random@abv.bg", Email = "random@abv.bg" },
                        UserId = "123456",
                        Currency = Currency.EUR,
                        EngineType = EngineType.Disel,
                        TransmissionType = TransmissionType.Automatic,
                        ManufactureDate = DateTime.UtcNow,
                    },
                },
            };
        }
    }
}
