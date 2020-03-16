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

            var emails = new List<string>() { "naskokolev00@gmail.com", "dochka_koleva@abv.bg", "danielIvanov99@gmail.com" };

            var defaultProfileImage = imagesService.GetAll().ToArray()[GlobalConstants.User.DefaultImageIndex];

            var naskoKolev = new ApplicationUser()
            {
                Email = emails[0],
                UserName = emails[0],
                Image = defaultProfileImage,
                ImageId = defaultProfileImage.Id,
            };

            var dochkaKoleva = new ApplicationUser()
            {
                Email = emails[1],
                UserName = emails[1],
                Image = defaultProfileImage,
                ImageId = defaultProfileImage.Id,
            };

            var danielIvanov = new ApplicationUser()
            {
                Email = emails[2],
                UserName = emails[2],
                Image = defaultProfileImage,
                ImageId = defaultProfileImage.Id,
            };

            await userManager.CreateAsync(naskoKolev, GlobalConstants.User.DefaultPassword);
            await userManager.CreateAsync(dochkaKoleva, GlobalConstants.User.DefaultPassword);
            await userManager.CreateAsync(danielIvanov, GlobalConstants.User.DefaultPassword);

            await userManager.AddToRoleAsync(naskoKolev, GlobalConstants.User.AdminRole);
            await userManager.AddToRoleAsync(dochkaKoleva, GlobalConstants.User.ModeratorRole);
            await userManager.AddToRoleAsync(danielIvanov, GlobalConstants.User.UserRole);
        }
    }
}
