﻿namespace Sabv.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Sabv.Data;
    using Sabv.Data.Models;
    using Sabv.Data.Repositories;
    using Xunit;

    public class FavouritesServiceTests
    {
        [Fact]
        public async Task GetAllUserFavouritesShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "GetAllUserFavouritesShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);
            dbContext.Favourites.Add(new Favourite());
            dbContext.Users.Add(new ApplicationUser() { Id = "TestId" });
            dbContext.Favourites.Add(new Favourite() { UserId = "TestId", PostId = 5 });
            await dbContext.SaveChangesAsync();

            var repository = new EfDeletableEntityRepository<Favourite>(dbContext);
            var service = new FavouritesService(repository);
            Assert.Single(service.GetAllUserFavourites("TestId"));
        }

        [Fact]
        public async Task AddAsyncShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "AddAsyncShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Favourite>(dbContext);
            var service = new FavouritesService(repository);

            await service.AddAsync(1, "test");
            Assert.True(repository.All().Any(x => x.PostId == 1 && x.UserId == "test"));
        }

        [Fact]
        public async Task AddAsyncShouldThrowArgumentExceptionForExistingEntity()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "AddAsyncShouldThrowArgumentExceptionForExistingEntity").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Favourite>(dbContext);
            var service = new FavouritesService(repository);

            await service.AddAsync(1, "test");
            await Assert.ThrowsAsync<ArgumentException>(() => service.AddAsync(1, "test"));
        }

        [Fact]
        public async Task RemoveAsyncShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "RemoveAsyncShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Favourite>(dbContext);
            var service = new FavouritesService(repository);

            await service.AddAsync(1, "test");
            Assert.Single(repository.All());
            await service.Remove(1, "test");
            Assert.Empty(repository.All());
        }

        [Fact]
        public async Task RemoveAsyncShouldThrowArgumentNullForNonExistingEntity()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "RemoveAsyncShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Favourite>(dbContext);
            var service = new FavouritesService(repository);

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.Remove(1, "test"));
        }
    }
}
