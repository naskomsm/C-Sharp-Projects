namespace Sabv.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Sabv.Data;
    using Sabv.Data.Models;
    using Sabv.Data.Repositories;
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
