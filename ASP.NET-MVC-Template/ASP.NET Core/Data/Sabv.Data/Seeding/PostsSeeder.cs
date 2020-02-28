namespace Sabv.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using Sabv.Data.Models;
    using Sabv.Services.Data;
    using Sabv.Services.Data.Contracts;
    using Sabv.Services.Models.Posts;

    public class PostsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var postsService = serviceProvider.GetRequiredService<IPostsService>();

            var additionalInfoService = serviceProvider.GetRequiredService<IAdditionalInfoService>();
            var mainInfoService = serviceProvider.GetRequiredService<IMainInfoService>();
            var postCategoryService = serviceProvider.GetRequiredService<IPostCategoriesService>();
            var vehicleCategoryService = serviceProvider.GetRequiredService<IVehicleTypeCategoriesService>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await SeedPostsAsync(postsService, additionalInfoService, mainInfoService, postCategoryService, vehicleCategoryService, userManager);
        }

        private static async Task SeedPostsAsync(
            IPostsService postsService,
            IAdditionalInfoService additionalInfoService,
            IMainInfoService mainInfoService,
            IPostCategoriesService postCategoriesService,
            IVehicleTypeCategoriesService vehicleCategoryService,
            UserManager<ApplicationUser> userManager)
        {
            var firstModel = new AddPostModel()
            {
                 AdditionalInfoId = additionalInfoService.GetAll().ToArray()[0].Id,
                 Make = "BMW",
                 Model = "M5",
                 Currency = 0,
                 Condition = 0,
                 Description = "Тази кола е уникално запазена и няма забележки по нея.. Коментар на цената само на място",
                 MainInfoId = mainInfoService.GetAll().ToArray()[0].Id,
                 Name = "BMW M5 F90",
                 PhoneNumber = "0899115617",
                 PostCategoryId = postCategoriesService.GetAllCategories().ToArray()[0].Id,
                 Price = 150000,
                 VehicleCategoryId = vehicleCategoryService.GetAllCategories().ToArray()[0].Id,
                 UserId = userManager.Users.ToArray()[0].Id,
            };

            var secondModel = new AddPostModel()
            {
                AdditionalInfoId = additionalInfoService.GetAll().ToArray()[1].Id,
                Description = "Ако си търсите готина количка за без паричка може да се отбиете тука при нас :D",
                MainInfoId = mainInfoService.GetAll().ToArray()[1].Id,
                Make = "Audi",
                Currency = 0,
                Condition = 0,
                Model = "RS 7",
                Name = "AUDI RS7",
                PhoneNumber = "0899115617",
                PostCategoryId = postCategoriesService.GetAllCategories().ToArray()[1].Id,
                Price = 260000,
                VehicleCategoryId = vehicleCategoryService.GetAllCategories().ToArray()[1].Id,
                UserId = userManager.Users.ToArray()[1].Id,
            };

            await postsService.AddPostAsync(firstModel);
            await postsService.AddPostAsync(secondModel);
        }
    }
}
