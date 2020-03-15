namespace Sabv.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;
    using Sabv.Services.Data;

    public class ColorSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Colors.Any())
            {
                return;
            }

            var service = serviceProvider.GetRequiredService<IColorService>();

            var colorsNames = new List<string>()
            {
                "Dark blue",
                "Banana",
                "Beata",
                "Beige",
                "Bordeaux",
                "Bronze",
                "White",
                "Wine",
                "Violet",
                "Cherry",
                "Graphite",
                "Yellow",
                "Green",
                "Gold",
                "Brown",
                "Brick",
                "Creamy",
                "Purple",
                "Metallic",
                "Orange",
                "Ohra",
                "Ashy",
                "Pearl",
                "Sandy",
                "Stayed",
                "Pink",
                "Sahara",
                "Light Grey",
                "Light Blue",
                "Grey",
                "Blue",
                "Ivory",
                "Silver",
                "Dark Green",
                "Dark Grey",
                "Dark Blue Metallic",
                "Dark Red",
                "Tobacco",
                "Chameleon",
                "Red",
                "Black",
            };

            foreach (var name in colorsNames)
            {
                await service.AddAsync(name);
            }
        }
    }
}
