namespace Sabv.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
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
            var password = "123456";

            var defaultProfileImage = imagesService.GetAll().ToArray()[3];

            foreach (var email in emails)
            {
                await userManager.CreateAsync(
                    new ApplicationUser()
                    {
                        Email = email,
                        UserName = email,
                        Image = defaultProfileImage,
                        ImageId = defaultProfileImage.Id,
                    }, password);
            }
        }
    }
}
