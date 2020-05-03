namespace Sabv.Web.Controllers
{
    using System.Diagnostics;

    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Sabv.Data.Models;
    using Sabv.Services.Mapping;
    using Sabv.Web.ViewModels;
    using Sabv.Web.ViewModels.Category;
    using Sabv.Web.ViewModels.Favourites;
    using Sabv.Web.ViewModels.Home;
    using Sabv.Web.ViewModels.Models;
    using Sabv.Web.ViewModels.Posts;

    public class BaseController : Controller
    {
        protected BaseController()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, Category>();
                cfg.CreateMap<City, City>();
                cfg.CreateMap<Color, Color>();
                cfg.CreateMap<Make, Make>();
                cfg.CreateMap<VehicleCategory, VehicleCategory>();
                cfg.CreateMap<Post, AllPagePostViewModel>();
                cfg.CreateMap<Post, PostDetailsViewModel>();
                cfg.CreateMap<Category, CategoryViewModel>();
                cfg.CreateMap<Post, FavouriteViewModel>();
                cfg.CreateMap<Post, PostIndexViewModel>();
                cfg.CreateMap<Model, ModelsReturnModel>();
            });

            var mapper = new Mapper(config);
            AutoMapperConfig.MapperInstance = mapper;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

        public IActionResult ProductionError()
        {
            return this.View();
        }
    }
}
