namespace Sabv.Controllers.Tests
{
    using System.Collections.Generic;

    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using Moq;
    using Sabv.Data.Models;
    using Sabv.Services.Mapping;
    using Sabv.Web.ViewModels.Posts;

    public class BaseClass
    {
        public BaseClass()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Post, AllPagePostViewModel>();
            });

            var mapper = new Mapper(config);
            AutoMapperConfig.MapperInstance = mapper;
        }

        public ICollection<T> GetAll<T>()
            where T : new()
        {
            return new List<T>()
            {
                new T(),
                new T(),
                new T(),
            };
        }

        public Mock<UserManager<ApplicationUser>> GetMockUserManager()
        {
            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            return new Mock<UserManager<ApplicationUser>>(
                userStoreMock.Object, null, null, null, null, null, null, null, null);
        }
    }
}
