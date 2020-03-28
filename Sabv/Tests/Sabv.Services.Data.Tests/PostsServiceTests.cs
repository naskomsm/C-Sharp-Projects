namespace Sabv.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Sabv.Data;
    using Sabv.Data.Models;
    using Sabv.Data.Models.Enums;
    using Sabv.Data.Repositories;
    using Sabv.Services.Mapping;
    using Sabv.Web.ViewModels.Posts;
    using Xunit;

    public class PostsServiceTests : BaseClass
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
        public async Task GetAllGenericShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "GetAllGenericShouldWork").Options;
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
                City = new City(),
                User = new ApplicationUser(),
                PhoneNumber = "0897456321",
                Description = "random descr",
                Eurostandard = Eurostandard.Five,
                Condition = Condition.New,
                VehicleCategory = new VehicleCategory(),
            };

            dbContext.Posts.Add(post);
            await dbContext.SaveChangesAsync();

            var postsRepo = new EfDeletableEntityRepository<Post>(dbContext);
            var makesRepo = new EfDeletableEntityRepository<Make>(dbContext);
            var makesService = new MakesService(makesRepo);
            var postsService = new PostsService(postsRepo, makesService);

            Assert.Single(postsService.GetAll<PostDetailsViewModel>());
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

        [Fact]
        public async Task GetLatestShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "GetLatestShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);

            var postsRepo = new EfDeletableEntityRepository<Post>(dbContext);
            var makesRepo = new EfDeletableEntityRepository<Make>(dbContext);
            var makesService = new MakesService(makesRepo);
            var postsService = new PostsService(postsRepo, makesService);

            var post1 = new Post()
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
                City = new City(),
                User = new ApplicationUser(),
                PhoneNumber = "0897456321",
                Description = "random descr",
                Eurostandard = Eurostandard.Five,
                Condition = Condition.New,
                VehicleCategory = new VehicleCategory(),
            };

            var post2 = new Post()
            {
                Id = 2,
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
                City = new City(),
                User = new ApplicationUser(),
                PhoneNumber = "0897456321",
                Description = "random descr",
                Eurostandard = Eurostandard.Five,
                Condition = Condition.New,
                VehicleCategory = new VehicleCategory(),
            };

            await dbContext.Posts.AddAsync(post1);
            await dbContext.Posts.AddAsync(post2);
            await dbContext.SaveChangesAsync();

            var result = postsService.GetLatest<PostDetailsViewModel>(1);
            Assert.Single(result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void GetLatestShouldThrowErrorForInvalidCount(int count)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "GetLatestShouldThrowErrorForInvalidCount").Options;
            var dbContext = new ApplicationDbContext(options);

            var postsRepo = new EfDeletableEntityRepository<Post>(dbContext);
            var makesRepo = new EfDeletableEntityRepository<Make>(dbContext);
            var makesService = new MakesService(makesRepo);
            var postsService = new PostsService(postsRepo, makesService);

            Assert.Throws<ArgumentNullException>(() => postsService.GetLatest<PostDetailsViewModel>(count));
        }

        [Fact]
        public async Task GetDetailsShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "GetDetailsShouldWork").Options;
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
                City = new City(),
                User = new ApplicationUser(),
                PhoneNumber = "0897456321",
                Description = "random descr",
                Eurostandard = Eurostandard.Five,
                Condition = Condition.New,
                VehicleCategory = new VehicleCategory(),
            };

            dbContext.Posts.Add(post);
            await dbContext.SaveChangesAsync();

            var postsRepo = new EfDeletableEntityRepository<Post>(dbContext);
            var makesRepo = new EfDeletableEntityRepository<Make>(dbContext);
            var makesService = new MakesService(makesRepo);
            var postsService = new PostsService(postsRepo, makesService);

            var expected = new List<Post>() { post }.AsQueryable().To<PostDetailsViewModel>().FirstOrDefault();
            var actual = postsService.GetDetails<PostDetailsViewModel>(1);
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.PhoneNumber, actual.PhoneNumber);
            Assert.Equal(expected.TransmissionType, actual.TransmissionType);
            Assert.Equal(expected.Description, actual.Description);
        }

        [Fact]
        public async Task GetDetailsShouldThrowArgumentNullException()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "GetDetailsShouldThrowException").Options;
            var dbContext = new ApplicationDbContext(options);

            var post = new Post();
            dbContext.Posts.Add(post);
            await dbContext.SaveChangesAsync();

            var postsRepo = new EfDeletableEntityRepository<Post>(dbContext);
            var makesRepo = new EfDeletableEntityRepository<Make>(dbContext);
            var makesService = new MakesService(makesRepo);
            var postsService = new PostsService(postsRepo, makesService);

            Assert.Throws<ArgumentNullException>(() => postsService.GetDetails<PostDetailsViewModel>(1));
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

        [Fact]
        public async Task AddImageToPostShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
          .UseInMemoryDatabase(databaseName: "AddImageToPostShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);

            var postsRepo = new EfDeletableEntityRepository<Post>(dbContext);
            var makesRepo = new EfDeletableEntityRepository<Make>(dbContext);
            var makesService = new MakesService(makesRepo);
            var postsService = new PostsService(postsRepo, makesService);

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
                City = new City(),
                User = new ApplicationUser(),
                PhoneNumber = "0897456321",
                Description = "random descr",
                Eurostandard = Eurostandard.Five,
                Condition = Condition.New,
                VehicleCategory = new VehicleCategory(),
            };

            var image = new Image()
            {
                Url = "random",
            };

            await dbContext.Images.AddAsync(image);
            await dbContext.Posts.AddAsync(post);
            await dbContext.SaveChangesAsync();

            var postImage = new PostImage()
            {
                Image = image,
                ImageId = image.Id,
                Post = post,
                PostId = post.Id,
            };

            await postsService.AddImageToPost(1, postImage);
            Assert.Single(post.Images);
        }

        [Fact]
        public async Task AddImageToPostShouldThrowArgumentNullException()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
          .UseInMemoryDatabase(databaseName: "AddImageToPostShouldThrowArgumentNullException").Options;
            var dbContext = new ApplicationDbContext(options);

            var postsRepo = new EfDeletableEntityRepository<Post>(dbContext);
            var makesRepo = new EfDeletableEntityRepository<Make>(dbContext);
            var makesService = new MakesService(makesRepo);
            var postsService = new PostsService(postsRepo, makesService);

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
                City = new City(),
                User = new ApplicationUser(),
                PhoneNumber = "0897456321",
                Description = "random descr",
                Eurostandard = Eurostandard.Five,
                Condition = Condition.New,
                VehicleCategory = new VehicleCategory(),
            };

            var image = new Image()
            {
                Url = "random",
            };

            await dbContext.Images.AddAsync(image);
            await dbContext.Posts.AddAsync(post);
            await dbContext.SaveChangesAsync();

            var postImage = new PostImage()
            {
                Image = image,
                ImageId = image.Id,
                Post = post,
                PostId = post.Id,
            };

            await Assert.ThrowsAsync<ArgumentNullException>(() => postsService.AddImageToPost(22, postImage));
        }

        [Fact]
        public async Task AddImageToPostShouldThrowArgumentNullExceptionForNullPostImage()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
          .UseInMemoryDatabase(databaseName: "AddImageToPostShouldThrowArgumentNullExceptionForNullPostImage").Options;
            var dbContext = new ApplicationDbContext(options);

            var postsRepo = new EfDeletableEntityRepository<Post>(dbContext);
            var makesRepo = new EfDeletableEntityRepository<Make>(dbContext);
            var makesService = new MakesService(makesRepo);
            var postsService = new PostsService(postsRepo, makesService);

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
                City = new City(),
                User = new ApplicationUser(),
                PhoneNumber = "0897456321",
                Description = "random descr",
                Eurostandard = Eurostandard.Five,
                Condition = Condition.New,
                VehicleCategory = new VehicleCategory(),
            };

            var image = new Image()
            {
                Url = "random",
            };

            await dbContext.Images.AddAsync(image);
            await dbContext.Posts.AddAsync(post);
            await dbContext.SaveChangesAsync();

            await Assert.ThrowsAsync<ArgumentNullException>(() => postsService.AddImageToPost(1, null));
        }

        [Fact]
        public async Task FilterShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
          .UseInMemoryDatabase(databaseName: "FilterShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);

            var postsRepo = new EfDeletableEntityRepository<Post>(dbContext);
            var makesRepo = new EfDeletableEntityRepository<Make>(dbContext);
            var makesService = new MakesService(makesRepo);
            var postsService = new PostsService(postsRepo, makesService);

            // BMW M5
            var inputModel = new PostDetailsInputModel()
            {
                Make = 1,
                Model = "M5",
                MaxMileage = 15000,
            };

            var post1 = new Post()
            {
                Make = new Make() { Name = "BMW" },
                Model = new Model() { Name = "M5" },
                Mileage = 14000,
            };

            var post2 = new Post()
            {
                Make = new Make() { Name = "BMW" },
                Model = new Model() { Name = "M5" },
                Mileage = 22000,
            };

            await postsService.AddAsync(post1);
            await postsService.AddAsync(post2);

            Assert.Single(postsService.Filter(inputModel));
        }
    }
}
