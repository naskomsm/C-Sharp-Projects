namespace Sabv.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using Sabv.Data.Models;
    using Sabv.Services.Data.Contracts;

    public class UsersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var imageService = serviceProvider.GetRequiredService<IImagesService>();
            await SeedUsersAsync(userManager, imageService);
        }

        private static async Task SeedUsersAsync(UserManager<ApplicationUser> userManager, IImagesService imagesService)
        {
            var defaultProfileImageUrl = await imagesService.UploadFileAsync("https://www.kindpng.com/picc/m/24-248729_stockvader-predicted-adig-user-profile-image-png-transparent.png");
            await imagesService.AddToBaseAsync(defaultProfileImageUrl);

            var firstUser = new ApplicationUser()
            {
                Email = "naskokolev00@gmail.com",
                UserName = "naskokolev00@gmail.com",
                ImageId = imagesService.GetAll().ToArray()[0].Id,
                Image = imagesService.GetAll().ToArray()[0],
            };


            var secondUser = new ApplicationUser()
            {
                Email = "danielivanov99@gmail.com",
                UserName = "danielivanov99@gmail.com",
                ImageId = imagesService.GetAll().ToArray()[0].Id,
                Image = imagesService.GetAll().ToArray()[0],
            };

            await userManager.CreateAsync(firstUser, "random123");
            await userManager.CreateAsync(secondUser, "random123");
        }
    }
}
