namespace Sabv.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;
    using Sabv.Services.Data;

    public class CategorySeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            var service = serviceProvider.GetRequiredService<ICategoriesService>();

            var categoryNames = new List<string>() { "Автомобили и джипове", "Бусове", "Камиони", "Мотоциклети" };

            foreach (var name in categoryNames)
            {
                await service.AddAsync(name);
            }
        }
    }
}
