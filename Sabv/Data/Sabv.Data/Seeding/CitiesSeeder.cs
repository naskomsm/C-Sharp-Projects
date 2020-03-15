namespace Sabv.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;
    using Sabv.Services.Data;

    public class CitiesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Cities.Any())
            {
                return;
            }

            var service = serviceProvider.GetRequiredService<ICitiesService>();

            var citiesNames = new List<string>()
            {
                 "Blagoevgrad",
                 "Burgas",
                 "Varna",
                 "Veliko Turnovo",
                 "Vidin",
                 "Vraca",
                 "Gabrovo",
                 "Dobrich",
                 "Dupnica",
                 "Kardjali",
                 "Kiustendil",
                 "Lovech",
                 "Montana",
                 "Pazardjik",
                 "Pernik",
                 "Pleven",
                 "Plovdiv",
                 "Razgrad",
                 "Ruse",
                 "Silistra",
                 "Sliven",
                 "Smolqn",
                 "Sofia",
                 "Stara Zagora",
                 "Targovishte",
                 "Haskovo",
                 "Shumen",
                 "Yambol",
            };

            foreach (var name in citiesNames)
            {
                await service.AddAsync(name);
            }
        }
    }
}
