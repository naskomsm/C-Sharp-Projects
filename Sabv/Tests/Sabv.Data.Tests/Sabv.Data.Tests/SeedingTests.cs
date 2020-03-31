namespace Sabv.Data.Tests
{
    using CloudinaryDotNet;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Sabv.Data.Models;
    using Sabv.Data.Repositories;
    using Sabv.Data.Seeding;
    using Sabv.Services.Data;
    using System;
    using System.Threading.Tasks;
    using Xunit;

    public class SeedingTests : BaseClass
    {
        [Fact]
        public async Task CategoySeederShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                 .UseInMemoryDatabase(databaseName: "CategoySeederShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);
            
            var categoriesRepository = new EfDeletableEntityRepository<Category>(dbContext);
            var imagesRepository = new EfDeletableEntityRepository<Image>(dbContext);

            var serviceProvider = new Mock<IServiceProvider>();
            serviceProvider
                .Setup(x => x.GetService(typeof(ICategoriesService)))
                .Returns(new CategoriesService(categoriesRepository));

            var imagesService = new ImagesService(imagesRepository);
            Account cloudinaryCredentials = new Account(
             this.Configuration["Cloudinary:CloudName"],
             this.Configuration["Cloudinary:ApiKey"],
             this.Configuration["Cloudinary:ApiSecret"]);
            Cloudinary cloudinary = new Cloudinary(cloudinaryCredentials);

            serviceProvider
                .Setup(x => x.GetService(typeof(ICloudinaryService)))
                .Returns(new CloudinaryService(cloudinary, imagesService));

            var seeder = new CategorySeeder();
            await seeder.SeedAsync(dbContext, serviceProvider.Object);

            Assert.NotEmpty(dbContext.Categories);
        }

        [Fact]
        public async Task CitiesSeederShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                 .UseInMemoryDatabase(databaseName: "CitiesSeederShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);
            var citiesRepository = new EfDeletableEntityRepository<City>(dbContext);

            var serviceProvider = new Mock<IServiceProvider>();
            serviceProvider
                .Setup(x => x.GetService(typeof(ICitiesService)))
                .Returns(new CitiesService(citiesRepository));

            var seeder = new CitiesSeeder();
            await seeder.SeedAsync(dbContext, serviceProvider.Object);
            Assert.NotEmpty(dbContext.Cities);
        }

        [Fact]
        public async Task ColorsSeederShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                 .UseInMemoryDatabase(databaseName: "ColorSeederShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);
            var colorsRepository = new EfDeletableEntityRepository<Color>(dbContext);

            var serviceProvider = new Mock<IServiceProvider>();
            serviceProvider
                .Setup(x => x.GetService(typeof(IColorService)))
                .Returns(new ColorService(colorsRepository));

            var seeder = new ColorSeeder();
            await seeder.SeedAsync(dbContext, serviceProvider.Object);
            Assert.NotEmpty(dbContext.Colors);
        }

        [Fact]
        public async Task ImagesSeederShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                 .UseInMemoryDatabase(databaseName: "ImagesSeederShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);

            var imagesRepository = new EfDeletableEntityRepository<Image>(dbContext);

            Account cloudinaryCredentials = new Account(
             this.Configuration["Cloudinary:CloudName"],
             this.Configuration["Cloudinary:ApiKey"],
             this.Configuration["Cloudinary:ApiSecret"]);
            Cloudinary cloudinary = new Cloudinary(cloudinaryCredentials);

            var imagesService = new ImagesService(imagesRepository);

            var serviceProvider = new Mock<IServiceProvider>();
            serviceProvider
                .Setup(x => x.GetService(typeof(IImagesService)))
                .Returns(imagesService);

            serviceProvider
                .Setup(x => x.GetService(typeof(ICloudinaryService)))
                .Returns(new CloudinaryService(cloudinary, imagesService));

            var seeder = new ImagesSeeder();
            await seeder.SeedAsync(dbContext, serviceProvider.Object);

            Assert.NotEmpty(dbContext.Images);
        }

        [Fact]
        public async Task MakesSeederShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                 .UseInMemoryDatabase(databaseName: "MakesSeederShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);
            var makesRepository = new EfDeletableEntityRepository<Make>(dbContext);

            var serviceProvider = new Mock<IServiceProvider>();
            serviceProvider
                .Setup(x => x.GetService(typeof(IMakesService)))
                .Returns(new MakesService(makesRepository));

            var seeder = new MakesSeeder();
            await seeder.SeedAsync(dbContext, serviceProvider.Object);
            Assert.NotEmpty(dbContext.Makes);
        }

        [Fact]
        public async Task ModelsSeederShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                 .UseInMemoryDatabase(databaseName: "ModelsSeederShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);
            
            var makesRepository = new EfDeletableEntityRepository<Make>(dbContext);
            var modelsRepositoory = new EfDeletableEntityRepository<Model>(dbContext);

            var serviceProvider = new Mock<IServiceProvider>();
            serviceProvider
                .Setup(x => x.GetService(typeof(IMakesService)))
                .Returns(new MakesService(makesRepository));
            serviceProvider
                .Setup(x => x.GetService(typeof(IModelsService)))
                .Returns(new ModelsService(modelsRepositoory));

            var makesSeeder = new MakesSeeder();
            await makesSeeder.SeedAsync(dbContext, serviceProvider.Object);

            var modelsSeeder = new ModelsSeeder();
            await modelsSeeder.SeedAsync(dbContext, serviceProvider.Object);
            Assert.NotEmpty(dbContext.Models);
        }

        [Fact]
        public async Task PostsSeederShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                 .UseInMemoryDatabase(databaseName: "PostsSeederShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);
            
            // Repos
            var postsRepository = new EfDeletableEntityRepository<Post>(dbContext);
            var categoriesRepository = new EfDeletableEntityRepository<Category>(dbContext);
            var vehicleCategoriesRepository = new EfDeletableEntityRepository<VehicleCategory>(dbContext);
            var colorsRepository = new EfDeletableEntityRepository<Color>(dbContext);
            var makesRepository = new EfDeletableEntityRepository<Make>(dbContext);
            var modelsRepository = new EfDeletableEntityRepository<Model>(dbContext);
            var citiesRepository = new EfDeletableEntityRepository<City>(dbContext);
            var imagesRepository = new EfDeletableEntityRepository<Image>(dbContext);

            // Setups
            var serviceProvider = new Mock<IServiceProvider>();
            var makesService = new MakesService(makesRepository);
            var imagesService = new ImagesService(imagesRepository);

            var userManager = this.GetUserManager(dbContext);

            Account cloudinaryCredentials = new Account(
            this.Configuration["Cloudinary:CloudName"],
            this.Configuration["Cloudinary:ApiKey"],
            this.Configuration["Cloudinary:ApiSecret"]);
            Cloudinary cloudinary = new Cloudinary(cloudinaryCredentials);

            await userManager.CreateAsync(new ApplicationUser() { UserName = "GOD" });
            serviceProvider
                .Setup(x => x.GetService(typeof(ICloudinaryService)))
                .Returns(new CloudinaryService(cloudinary, imagesService));
            serviceProvider
                .Setup(x => x.GetService(typeof(IPostsService)))
                .Returns(new PostsService(postsRepository, makesService));
            serviceProvider
                .Setup(x => x.GetService(typeof(ICategoriesService)))
                .Returns(new CategoriesService(categoriesRepository));
            serviceProvider
                .Setup(x => x.GetService(typeof(IVehicleCategoriesService)))
                .Returns(new VehicleCategoriesService(vehicleCategoriesRepository));
            serviceProvider
                .Setup(x => x.GetService(typeof(IColorService)))
                .Returns(new ColorService(colorsRepository));
            serviceProvider
                .Setup(x => x.GetService(typeof(ICategoriesService)))
                .Returns(new CategoriesService(categoriesRepository));
            serviceProvider
                .Setup(x => x.GetService(typeof(IMakesService)))
                .Returns(makesService);
            serviceProvider
                .Setup(x => x.GetService(typeof(IModelsService)))
                .Returns(new ModelsService(modelsRepository));
            serviceProvider
                .Setup(x => x.GetService(typeof(ICitiesService)))
                .Returns(new CitiesService(citiesRepository));
            serviceProvider
                .Setup(x => x.GetService(typeof(IImagesService)))
                .Returns(imagesService);
            serviceProvider
                .Setup(x => x.GetService(typeof(UserManager<ApplicationUser>)))
                .Returns(userManager);

            // Categories
            var categoriesSeeder = new CategorySeeder();
            await categoriesSeeder.SeedAsync(dbContext, serviceProvider.Object);

            // Vehicle cateogories
            var vehicleCategoriesSeeder = new VehicleCategorySeeder();
            await vehicleCategoriesSeeder.SeedAsync(dbContext, serviceProvider.Object);

            // Colors
            var colorsSeeder = new ColorSeeder();
            await colorsSeeder.SeedAsync(dbContext, serviceProvider.Object);

            // Makes
            var makesSeeder = new MakesSeeder();
            await makesSeeder.SeedAsync(dbContext, serviceProvider.Object);

            // Models
            var modelsSeeder = new ModelsSeeder();
            await modelsSeeder.SeedAsync(dbContext, serviceProvider.Object);

            // Cities
            var citiesSeeder = new CitiesSeeder();
            await citiesSeeder.SeedAsync(dbContext, serviceProvider.Object);

            // Posts
            var postsSeeder = new PostsSeeder();
            await postsSeeder.SeedAsync(dbContext, serviceProvider.Object);
            Assert.NotEmpty(dbContext.Posts);
        }

        [Fact]
        public async Task UsersSeederShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                 .UseInMemoryDatabase(databaseName: "UsersSeederShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);
           
            var imagesRepository = new EfDeletableEntityRepository<Image>(dbContext);
            var userManager = this.GetUserManager(dbContext);
            await userManager.CreateAsync(new ApplicationUser() { UserName = "GOD" });
            await userManager.CreateAsync(new ApplicationUser() { UserName = "BRATmu" });

            var serviceProvider = new Mock<IServiceProvider>();
            serviceProvider
                .Setup(x => x.GetService(typeof(UserManager<ApplicationUser>)))
                .Returns(userManager);

            var seeder = new UsersSeeder();
            await seeder.SeedAsync(dbContext, serviceProvider.Object);
            Assert.NotEmpty(dbContext.Users);
        }

        [Fact]
        public async Task VehicleCategorySeederShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                 .UseInMemoryDatabase(databaseName: "VehicleCategorySeederShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);

            var vehicleCategoriesRepository = new EfDeletableEntityRepository<VehicleCategory>(dbContext);
            var serviceProvider = new Mock<IServiceProvider>();
            serviceProvider
              .Setup(x => x.GetService(typeof(IVehicleCategoriesService)))
              .Returns(new VehicleCategoriesService(vehicleCategoriesRepository));

            var seeder = new VehicleCategorySeeder();
            await seeder.SeedAsync(dbContext, serviceProvider.Object);
            Assert.NotEmpty(dbContext.VehicleCategories);
        }
    }
}
