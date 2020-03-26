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

            var admin = new ApplicationUser()
            {
                Email = emails[0],
                UserName = "GOD",
                Image = defaultProfileImage,
                ImageId = defaultProfileImage.Id,
            };

            var moderator = new ApplicationUser()
            {
                Email = emails[1],
                UserName = "Child of GOD",
                Image = defaultProfileImage,
                ImageId = defaultProfileImage.Id,
            };

            var user = new ApplicationUser()
            {
                Email = emails[2],
                UserName = "Peasant",
                Image = defaultProfileImage,
                ImageId = defaultProfileImage.Id,
            };

            await userManager.CreateAsync(admin, GlobalConstants.User.DefaultPassword);
            await userManager.CreateAsync(moderator, GlobalConstants.User.DefaultPassword);
            await userManager.CreateAsync(user, GlobalConstants.User.DefaultPassword);

            await userManager.AddToRoleAsync(admin, GlobalConstants.User.AdminRole);
            await userManager.AddToRoleAsync(moderator, GlobalConstants.User.ModeratorRole);
            await userManager.AddToRoleAsync(user, GlobalConstants.User.UserRole);
        }
    }
}
