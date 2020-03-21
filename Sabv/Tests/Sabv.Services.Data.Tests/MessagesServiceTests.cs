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

    public class MessagesServiceTests
    {
        [Fact]
        public async Task GetAllShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "GetAllShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);
            dbContext.Messages.Add(new Message());
            dbContext.Messages.Add(new Message());
            dbContext.Messages.Add(new Message());
            await dbContext.SaveChangesAsync();

            var repository = new EfDeletableEntityRepository<Message>(dbContext);
            var service = new MessagesService(repository);
            Assert.Equal(3, service.GetAll().Count());
        }

        [Fact]
        public async Task AddAsyncShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "AddAsyncShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);
            var repository = new EfDeletableEntityRepository<Message>(dbContext);
            var service = new MessagesService(repository);

            await service.AddAsync("content", new ApplicationUser());
            Assert.Single(service.GetAll());
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task AddAsyncShouldThrowAgrumentNullForInvalidContent(string content)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                       .UseInMemoryDatabase(databaseName: "AddAsyncShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);
            var repository = new EfDeletableEntityRepository<Message>(dbContext);
            var service = new MessagesService(repository);

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.AddAsync(content, new ApplicationUser()));
        }

        [Fact]
        public async Task AddAsyncShouldThrowAgrumentNullForInvalidUser()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                       .UseInMemoryDatabase(databaseName: "AddAsyncShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);
            var repository = new EfDeletableEntityRepository<Message>(dbContext);
            var service = new MessagesService(repository);

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.AddAsync("random", null));
        }

        [Fact]
        public async Task DeleteAsyncShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                       .UseInMemoryDatabase(databaseName: "DeleteAsyncShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);
            var repository = new EfDeletableEntityRepository<Message>(dbContext);
            var service = new MessagesService(repository);

            await service.AddAsync("zdr", new ApplicationUser());
            Assert.Single(service.GetAll());
            await service.DeleteAsync(1);
            Assert.Empty(service.GetAll());
        }

        [Fact]
        public async Task DeleteAsyncShouldThrowNullExceptionForNotFound()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                      .UseInMemoryDatabase(databaseName: "DeleteAsyncShouldThrowNullExceptionForNotFound").Options;
            var dbContext = new ApplicationDbContext(options);
            var repository = new EfDeletableEntityRepository<Message>(dbContext);
            var service = new MessagesService(repository);

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.DeleteAsync(1));
        }
    }
}
