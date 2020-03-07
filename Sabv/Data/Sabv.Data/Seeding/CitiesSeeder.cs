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
                 "Благоевград",
                 "Бургас",
                 "Варна",
                 "Велико Търново",
                 "Видин",
                 "Враца",
                 "Габрово",
                 "Добрич",
                 "Дупница",
                 "Кърджали",
                 "Кюстендил",
                 "Ловеч",
                 "Монтана",
                 "Пазарджик",
                 "Перник",
                 "Плевен",
                 "Пловдив",
                 "Разград",
                 "Русе",
                 "Силистра",
                 "Сливен",
                 "Смолян",
                 "София",
                 "Стара Загора",
                 "Търговище",
                 "Хасково",
                 "Шумен",
                 "Ямбол",
            };

            foreach (var name in citiesNames)
            {
                await service.AddAsync(name);
            }
        }
    }
}
