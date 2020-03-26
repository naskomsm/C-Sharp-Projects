namespace Sabv.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using Sabv.Common;
    using Sabv.Data.Models;
    using Sabv.Services.Data;

    public class UsersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Users.Any())
            {
                return;
            }

            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var imagesService = serviceProvider.GetRequiredService<IImagesService>();

            var emails = new List<string>() { "admin@gmail.com", "moderator@gmail.com", "user@gmail.com" };

            var defaultProfileImage = imagesService.GetAll().ToArray()[GlobalConstants.User.DefaultImageIndex];

            var firstUser = new ApplicationUser()
            {
                Email = emails[0],
                UserName = "GOD",
                Image = defaultProfileImage,
                ImageId = defaultProfileImage.Id,
            };

            var secondUser = new ApplicationUser()
            {
                Email = emails[1],
                UserName = "GodsChild",
                Image = defaultProfileImage,
                ImageId = defaultProfileImage.Id,
            };

            var thirdUser = new ApplicationUser()
            {
                Email = emails[2],
                UserName = "Peasant",
                Image = defaultProfileImage,
                ImageId = defaultProfileImage.Id,
            };

            await userManager.CreateAsync(firstUser, GlobalConstants.User.DefaultPassword);
            await userManager.CreateAsync(secondUser, GlobalConstants.User.DefaultPassword);
            await userManager.CreateAsync(thirdUser, GlobalConstants.User.DefaultPassword);

            await userManager.AddToRoleAsync(firstUser, GlobalConstants.User.AdminRole);
            await userManager.AddToRoleAsync(secondUser, GlobalConstants.User.ModeratorRole);
            await userManager.AddToRoleAsync(thirdUser, GlobalConstants.User.UserRole);
        }
    }
}
