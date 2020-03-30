namespace Sabv.Services.Data.Tests
{
    using AutoMapper;
    using Microsoft.Extensions.Configuration;
    using Sabv.Data.Models;
    using Sabv.Services.Mapping;
    using Sabv.Web.ViewModels.Category;
    using Sabv.Web.ViewModels.Comments;
    using Sabv.Web.ViewModels.Favourites;
    using Sabv.Web.ViewModels.Models;
    using Sabv.Web.ViewModels.Posts;

    using static Sabv.Services.Data.Tests.MessagesServiceTests;

    public class BaseClass
    {
        protected BaseClass()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, CategoryViewModel>();
                cfg.CreateMap<City, City>();
                cfg.CreateMap<Color, Color>();
                cfg.CreateMap<Comment, CommentViewModel>();
                cfg.CreateMap<Favourite, FavouriteViewModel>();
                cfg.CreateMap<Image, Image>();
                cfg.CreateMap<Make, Make>();
                cfg.CreateMap<Message, MessageModel>();
                cfg.CreateMap<Model, ModelsReturnModel>();
                cfg.CreateMap<Model, ModelsReturnModel>();
                cfg.CreateMap<Post, PostDetailsViewModel>();
                cfg.CreateMap<Post, FavouriteViewModel>();
                cfg.CreateMap<Post, Post>();
                cfg.CreateMap<VehicleCategory, VehicleCategory>();
            });

            var mapper = new Mapper(config);
            AutoMapperConfig.MapperInstance = mapper;

            this.Configuration = new ConfigurationBuilder()
                .AddJsonFile("mockappsettings.Development.json")
                .Build();
        }

        protected IConfiguration Configuration { get; set; }
    }
}
