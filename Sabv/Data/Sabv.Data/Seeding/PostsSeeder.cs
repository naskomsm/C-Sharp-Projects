namespace Sabv.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using Sabv.Common;
    using Sabv.Data.Models.Enums;
    using Sabv.Data.Models.Posts;
    using Sabv.Data.Models.PostsImages;
    using Sabv.Data.Models.Users;
    using Sabv.Services.Data;

    public class PostsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var postsService = serviceProvider.GetRequiredService<IPostsService>();
            var extrasService = serviceProvider.GetRequiredService<IExtrasService>();
            var vehicleCategoryService = serviceProvider.GetRequiredService<IVehicleCategoryService>();
            var categoryService = serviceProvider.GetRequiredService<ICategoryService>();
            var makesService = serviceProvider.GetRequiredService<IMakesService>();
            var citiesService = serviceProvider.GetRequiredService<ICitiesService>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var cloudinary = serviceProvider.GetRequiredService<ICloudinaryService>();
            var imagesService = serviceProvider.GetRequiredService<IImageService>();

            await SeedPostsAsync(
                postsService,
                extrasService,
                vehicleCategoryService,
                categoryService,
                makesService,
                citiesService,
                userManager,
                cloudinary,
                imagesService);
        }

        private static async Task SeedPostsAsync(
            IPostsService postsService,
            IExtrasService extrasService,
            IVehicleCategoryService vehicleCategoryService,
            ICategoryService categoryService,
            IMakesService makesService,
            ICitiesService citiesService,
            UserManager<ApplicationUser> userManager,
            ICloudinaryService cloudinaryService,
            IImageService imageService)
        {
            await cloudinaryService.UploadAsync(GlobalConstants.DefaultImageForPost);

            var firstPost = new Post()
            {
                ApplicationUserId = userManager.Users.ToArray()[0].Id,
                ApplicationUser = userManager.Users.ToArray()[0],
                Category = categoryService.GetById(1),
                CategoryId = 1,
                City = citiesService.GetById(1),
                CityId = 1,
                Color = "Син",
                Comfort = extrasService.GetByIdComfort(1),
                ComfortId = 1,
                CreatedOn = DateTime.UtcNow,
                Description = "Random description 1",
                EngineType = EngineType.Petrol,
                Eurostandard = Eurostandard.Six,
                Exterior = extrasService.GetByIdExterior(1),
                ExteriorId = 1,
                Horsepower = 625,
                Make = makesService.GetById(1),
                MakeId = 1,
                ManufactureDate = DateTime.UtcNow.AddDays(-150),
                IsDeleted = false,
                Mileage = 150000,
                Name = makesService.GetById(1).Name,
                Other = extrasService.GetByIdOther(1),
                OtherId = 1,
                PhoneNumber = "0899115617",
                Price = 125000,
                Safety = extrasService.GetByIdSafety(1),
                SafetyId = 1,
                TransmissionType = TransmissionType.Automatic,
                VehicleCategory = vehicleCategoryService.GetById(1),
                VehicleCategoryId = 1,
            };

            var secondPost = new Post()
            {
                ApplicationUserId = userManager.Users.ToArray()[0].Id,
                ApplicationUser = userManager.Users.ToArray()[0],
                Category = categoryService.GetById(2),
                CategoryId = 2,
                City = citiesService.GetById(2),
                CityId = 2,
                Color = "Червен",
                Comfort = extrasService.GetByIdComfort(1),
                ComfortId = 1,
                CreatedOn = DateTime.UtcNow,
                Description = "Random description 2",
                EngineType = EngineType.Disel,
                Eurostandard = Eurostandard.Five,
                Exterior = extrasService.GetByIdExterior(1),
                ExteriorId = 1,
                Horsepower = 625,
                Make = makesService.GetById(2),
                MakeId = 2,
                ManufactureDate = DateTime.UtcNow.AddDays(-150),
                IsDeleted = false,
                Mileage = 150000,
                Name = makesService.GetById(2).Name,
                Other = extrasService.GetByIdOther(1),
                OtherId = 1,
                PhoneNumber = "0899115617",
                Price = 125000,
                Safety = extrasService.GetByIdSafety(1),
                SafetyId = 1,
                TransmissionType = TransmissionType.Manual,
                VehicleCategory = vehicleCategoryService.GetById(2),
                VehicleCategoryId = 2,
            };


            firstPost.Images.Add(new PostImage { ImageId = 1, Post = firstPost });
            secondPost.Images.Add(new PostImage { ImageId = 1, Post = secondPost });

            await postsService.AddAsync(firstPost);
            await postsService.AddAsync(secondPost);
        }
    }
}
