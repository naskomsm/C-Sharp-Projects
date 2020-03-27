namespace Sabv.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Mapping;
    using Microsoft.EntityFrameworkCore;
    using Sabv.Data;
    using Sabv.Data.Models;
    using Sabv.Data.Models.Enums;
    using Sabv.Data.Repositories;
    using Sabv.Web.ViewModels.Posts;
    using Xunit;

    public class PostsServiceTests
    {
        [Fact]
        public async Task GetAllShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "GetAllShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);
            dbContext.Posts.Add(new Post());
            dbContext.Posts.Add(new Post());
            dbContext.Posts.Add(new Post());
            await dbContext.SaveChangesAsync();

            var postsRepo = new EfDeletableEntityRepository<Post>(dbContext);
            var makesRepo = new EfDeletableEntityRepository<Make>(dbContext);
            var makesService = new MakesService(makesRepo);
            var postsService = new PostsService(postsRepo, makesService);

            Assert.Equal(3, postsService.GetAll().Count());
        }

        [Fact]
        public async Task TotalShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TotalShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);
            dbContext.Posts.Add(new Post());
            dbContext.Posts.Add(new Post());
            dbContext.Posts.Add(new Post());
            await dbContext.SaveChangesAsync();

            var postsRepo = new EfDeletableEntityRepository<Post>(dbContext);
            var makesRepo = new EfDeletableEntityRepository<Make>(dbContext);
            var makesService = new MakesService(makesRepo);
            var postsService = new PostsService(postsRepo, makesService);

            Assert.Equal(3, postsService.Total());
        }

        [Fact]
        public async Task AddAsyncShouldThrowNullExceptionForInvalidPost()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "AddAsyncShouldThrowNullExceptionForInvalidPost").Options;
            var dbContext = new ApplicationDbContext(options);
            await dbContext.SaveChangesAsync();

            var postsRepo = new EfDeletableEntityRepository<Post>(dbContext);
            var makesRepo = new EfDeletableEntityRepository<Make>(dbContext);
            var makesService = new MakesService(makesRepo);
            var postsService = new PostsService(postsRepo, makesService);

            await Assert.ThrowsAsync<ArgumentNullException>(() => postsService.AddAsync(null));
        }

        [Fact]
        public async Task AddAsyncShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "AddAsyncShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);

            var postsRepo = new EfDeletableEntityRepository<Post>(dbContext);
            var makesRepo = new EfDeletableEntityRepository<Make>(dbContext);
            var makesService = new MakesService(makesRepo);
            var postsService = new PostsService(postsRepo, makesService);

            Assert.Empty(postsService.GetAll());

            await postsService.AddAsync(new Post());

            Assert.Single(postsService.GetAll());
        }

        // public async Task GetLatestShouldWork()
        // {
        //    var options = new DbContextOptionsBuilder<ApplicationDbContext>()
        //    .UseInMemoryDatabase(databaseName: "GetLatestShouldWork").Options;
        //    var dbContext = new ApplicationDbContext(options);

        // var postsRepo = new EfDeletableEntityRepository<Post>(dbContext);
        //    var makesRepo = new EfDeletableEntityRepository<Make>(dbContext);
        //    var makesService = new MakesService(makesRepo);
        //    var postsService = new PostsService(postsRepo, makesService);

        // await postsService.AddAsync(new Post());
        //    Assert.Single(postsService.GetLatest<Post>(1));
        // }

        // public async Task GetDetailsShouldWork()
        // {
        //    var options = new DbContextOptionsBuilder<ApplicationDbContext>()
        //    .UseInMemoryDatabase(databaseName: "GetLatestShouldWork").Options;
        //    var dbContext = new ApplicationDbContext(options);

        // var postsRepo = new EfDeletableEntityRepository<Post>(dbContext);
        //    var makesRepo = new EfDeletableEntityRepository<Make>(dbContext);
        //    var makesService = new MakesService(makesRepo);
        //    var postsService = new PostsService(postsRepo, makesService);
        // }

        [Fact]
        public async Task GetDetailsShouldWork()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Post, PostDetailsViewModel>();
            });

            var mapper = new Mapper(config);
            mapper.Map(typeof(Post), typeof(PostDetailsViewModel));

            AutoMapperConfig.MapperInstance = mapper;

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "GetLatestShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);

            var post = new Post()
            {
                Id = 1,
                Name = "random name",
                Price = 53222,
                Currency = Currency.LV,
                Mileage = 25123,
                Color = new Color(),
                EngineType = EngineType.Disel,
                Horsepower = 255,
                TransmissionType = TransmissionType.Automatic,
                ManufactureDate = DateTime.Now,
                Category = new Category(),
                User = new ApplicationUser(),
                PhoneNumber = "0894756154",
                Description = "random",
                VehicleCategory = new VehicleCategory(),
                Condition = Condition.New,
            };

            dbContext.Posts.Add(post);
            await dbContext.SaveChangesAsync();

            var postsRepo = new EfDeletableEntityRepository<Post>(dbContext);
            var makesRepo = new EfDeletableEntityRepository<Make>(dbContext);
            var makesService = new MakesService(makesRepo);
            var postsService = new PostsService(postsRepo, makesService);

            var expected = new List<Post>() { post }.AsQueryable().To<PostDetailsViewModel>();
            Assert.Same(expected.FirstOrDefault(), postsService.GetDetails<PostDetailsViewModel>(1));
        }

        [Fact]
        public async Task DeleteAsyncShouldThrowNullExceptionForNotFound()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "DeleteAsyncShouldThrowNullExceptionForNotFound").Options;
            var dbContext = new ApplicationDbContext(options);

            var postsRepo = new EfDeletableEntityRepository<Post>(dbContext);
            var makesRepo = new EfDeletableEntityRepository<Make>(dbContext);
            var makesService = new MakesService(makesRepo);
            var postsService = new PostsService(postsRepo, makesService);

            await Assert.ThrowsAsync<ArgumentNullException>(() => postsService.DeleteAsync(1));
        }

        [Fact]
        public async Task DeleteAsyncShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "DeleteAsyncShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);

            var postsRepo = new EfDeletableEntityRepository<Post>(dbContext);
            var makesRepo = new EfDeletableEntityRepository<Make>(dbContext);
            var makesService = new MakesService(makesRepo);
            var postsService = new PostsService(postsRepo, makesService);

            await postsService.AddAsync(new Post());
            Assert.Single(postsService.GetAll());
            await postsService.DeleteAsync(1);
            Assert.Empty(postsService.GetAll());
        }
    }
}
