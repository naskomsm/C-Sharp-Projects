namespace Sabv.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using Sabv.Data.Models;

    internal class RolesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            await roleManager.CreateAsync(new ApplicationRole
            {
                Name = "Admin",
            });

            await roleManager.CreateAsync(new ApplicationRole
            {
                Name = "Moderator",
            });

            await roleManager.CreateAsync(new ApplicationRole
            {
                Name = "User",
            });
        }
    }
}
