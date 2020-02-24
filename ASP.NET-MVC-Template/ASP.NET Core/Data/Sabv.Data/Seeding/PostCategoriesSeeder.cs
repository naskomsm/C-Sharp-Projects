namespace Sabv.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;
    using Sabv.Services.Data;
    using Sabv.Services.Data.Contracts;

    public class PostCategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var postCategoriesService = serviceProvider.GetRequiredService<IPostCategoriesService>();
            await SeedPostCategoriesAsync(postCategoriesService);
        }

        private static async Task SeedPostCategoriesAsync(IPostCategoriesService postCategoriesService)
        {
            await postCategoriesService.AddAsync("Автомобили и джипове");
            await postCategoriesService.AddAsync("Мотоциклети");
            await postCategoriesService.AddAsync("Бусове");
        }
    }
}
