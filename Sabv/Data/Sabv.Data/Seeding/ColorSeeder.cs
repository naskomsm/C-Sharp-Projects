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
                "Tъмно син",
                "Банан",
                "Беата",
                "Бежов",
                "Бордо",
                "Бронз",
                "Бял",
                "Винен",
                "Виолетов",
                "Вишнев",
                "Графит",
                "Жълт",
                "Зелен",
                "Златист",
                "Кафяв",
                "Керемиден",
                "Кремав",
                "Лилав",
                "Металик",
                "Оранжев",
                "Охра",
                "Пепеляв",
                "Перла",
                "Пясъчен",
                "Резидав",
                "Розов",
                "Сахара",
                "Светло сив",
                "Светло син",
                "Сив",
                "Син",
                "Слонова кост",
                "Сребърен",
                "Т.зелен",
                "Тъмно сив",
                "Тъмно син мет.",
                "Тъмно червен",
                "Тютюн",
                "Хамелеон",
                "Червен",
                "Черен",
            };

            foreach (var name in colorsNames)
            {
                await service.AddAsync(name);
            }
        }
    }
}
