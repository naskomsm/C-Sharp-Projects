namespace Sabv.Services.Data.Tests
{
    using AutoMapper;
    using Sabv.Data.Models;
    using Sabv.Services.Mapping;
    using Sabv.Web.ViewModels.Category;
    using Sabv.Web.ViewModels.Comments;
    using Sabv.Web.ViewModels.Favourites;
    using Sabv.Web.ViewModels.Models;
    using static Sabv.Services.Data.Tests.MessagesServiceTests;

    public class BaseClass
    {
        public BaseClass()
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
            });

            var mapper = new Mapper(config);
            mapper.Map(typeof(Category), typeof(CategoryViewModel));
            mapper.Map(typeof(City), typeof(City));
            mapper.Map(typeof(Color), typeof(Color));
            mapper.Map(typeof(Comment), typeof(CommentViewModel));
            mapper.Map(typeof(Favourite), typeof(FavouriteViewModel));
            mapper.Map(typeof(Image), typeof(Image));
            mapper.Map(typeof(Make), typeof(Make));
            mapper.Map(typeof(Message), typeof(MessageModel));
            mapper.Map(typeof(Model), typeof(ModelsReturnModel));

            AutoMapperConfig.MapperInstance = mapper;
        }
    }
}
