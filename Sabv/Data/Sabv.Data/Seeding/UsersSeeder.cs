namespace Sabv.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using Sabv.Data.Models.Users;

    public class UsersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            await SeedUsersAsync(userManager);
        }

        private static async Task SeedUsersAsync(UserManager<ApplicationUser> userManager)
        {
            var firstUser = new ApplicationUser()
            {
                Email = "naskokolev00@gmail.com",
                UserName = "naskokolev00@gmail.com",
            };

            var secondUser = new ApplicationUser()
            {
                Email = "danielivanov99@gmail.com",
                UserName = "danielivanov99@gmail.com",
            };

            await userManager.CreateAsync(firstUser, "random123");
            await userManager.CreateAsync(secondUser, "random123");
        }
    }
}
