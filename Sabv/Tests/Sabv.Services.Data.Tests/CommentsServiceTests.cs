namespace Sabv.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Sabv.Data;
    using Sabv.Data.Models;
    using Sabv.Data.Repositories;
    using Sabv.Services.Mapping;
    using Sabv.Web.ViewModels.Comments;
    using Xunit;

    public class CommentsServiceTests : BaseClass
    {
        [Theory]
        [InlineData("Hello bro")]
        public async Task AddAsyncShouldWork(string content)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "AddAsync").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Comment>(dbContext);
            var service = new CommentsService(repository);
            await service.AddAsync(content, new ApplicationUser(), new Post());
            Assert.True(repository.All().Any(x => x.Content == content));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task AddAsyncShouldThrowNullExceptionForContent(string content)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "AddAsync").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Comment>(dbContext);
            var service = new CommentsService(repository);
            await Assert.ThrowsAsync<ArgumentNullException>(() => service.AddAsync(content, new ApplicationUser(), new Post()));
        }

        [Fact]
        public async Task AddAsyncShouldThrowNullExceptionForUser()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "AddAsync").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Comment>(dbContext);
            var service = new CommentsService(repository);
            await Assert.ThrowsAsync<ArgumentNullException>(() => service.AddAsync("content", null, new Post()));
        }

        [Fact]
        public async Task AddAsyncShouldThrowNullExceptionForPost()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "AddAsync").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Comment>(dbContext);
            var service = new CommentsService(repository);
            await Assert.ThrowsAsync<ArgumentNullException>(() => service.AddAsync("content", new ApplicationUser(), null));
        }

        [Fact]
        public async Task DeleteAsyncShouldThrowNullException()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "AddAsync").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Comment>(dbContext);
            var service = new CommentsService(repository);

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.DeleteAsync(-5));
        }

        [Fact]
        public async Task DeleteAsyncShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "DeleteAsync").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Comment>(dbContext);
            var service = new CommentsService(repository);

            await service.AddAsync("content", new ApplicationUser(), new Post());
            Assert.True(repository.All().Any(x => x.Content == "content"));
            Assert.Single(service.GetAll());

            await service.DeleteAsync(1);
            Assert.Empty(service.GetAll());
        }

        [Fact]
        public async Task LikeShouldThrowNullException()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "AddAsync").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Comment>(dbContext);
            var service = new CommentsService(repository);

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.Like(-5, new ApplicationUser()));
        }

        [Fact]
        public async Task LikeShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "AddAsync").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Comment>(dbContext);
            var service = new CommentsService(repository);

            await service.AddAsync("content", new ApplicationUser(), new Post());
            await service.Like(1, new ApplicationUser());
            Assert.Equal(1, service.GetAll().FirstOrDefault(x => x.Content == "content").UserLikes.Count);
        }

        [Fact]
        public async Task GetAllShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "GetAll").Options;
            var dbContext = new ApplicationDbContext(options);
            dbContext.Comments.Add(new Comment());
            dbContext.Comments.Add(new Comment());
            dbContext.Comments.Add(new Comment());
            await dbContext.SaveChangesAsync();

            var repository = new EfDeletableEntityRepository<Comment>(dbContext);
            var service = new CommentsService(repository);
            Assert.Equal(3, service.GetAll().Count());
        }

        [Fact]
        public async Task GetAllGenericShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "GetAllGeneric").Options;
            var dbContext = new ApplicationDbContext(options);
            dbContext.Comments.Add(new Comment() { PostId = 1, User = new ApplicationUser() });
            dbContext.Comments.Add(new Comment() { PostId = 2, User = new ApplicationUser() });
            dbContext.Comments.Add(new Comment() { PostId = 3, User = new ApplicationUser() });
            await dbContext.SaveChangesAsync();

            var repository = new EfDeletableEntityRepository<Comment>(dbContext);
            var service = new CommentsService(repository);
            Assert.Equal(3, service.GetAll<CommentViewModel>().Count());
        }
    }
}
