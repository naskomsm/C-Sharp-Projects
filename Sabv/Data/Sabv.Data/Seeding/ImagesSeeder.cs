namespace Sabv.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;
    using Sabv.Services.Data;

    public class ImagesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Images.Any())
            {
                return;
            }

            var service = serviceProvider.GetRequiredService<ICloudinaryService>();

            // first 4 are default
            // 0 - 3 BMW M5 E60
            // 4 - 8 Audi RS7 RS 7 Sportback
            // 9 - 13 Mercedes-Benz S600
            // 14 - 18 BMW M3 F80
            // 19 - 22 BMW M5 F10
            // 23 - 27 Audi RS6 C7
            // 28 - 32 Mercedes-Benz G-Class G500
            var links = new List<string>()
            {
                "http://www.acornexclusivecars.com/Acorn-Exclusive-Cars-Audi-A6-900x350.png",
                "https://irp-cdn.multiscreensite.com/30709730/dms3rep/multi/desktop/slide-2-900x350.jpg",
                "https://irp-cdn.multiscreensite.com/30709730/dms3rep/multi/desktop/slide-1-900x350.jpg",
                "https://www.kindpng.com/picc/m/24-248729_stockvader-predicted-adig-user-profile-image-png-transparent.png",

                "https://bg.autodata24.com/i/bmw/m5/m5-e60/large/516cad2b6f6521b3ff16ffc1547d3029.jpg",
                "https://bg.autodata24.com/i/bmw/m5/m5-e60/large/20a25cb2b439604fe5db3c205f7e11b5.jpg",
                "https://bg.autodata24.com/i/bmw/m5/m5-e60/large/55728f87f5f5323e66adae0de09952e3.jpg",
                "https://bg.autodata24.com/i/bmw/m5/m5-e60/large/1fe1536f178a88853c1f2d616cf1c180.jpg",

                "https://bg.autodata24.com/i/audi/rs7/rs-7-sportback-4g/large/af4fb54791132b1e2890f2d5737a3981.jpg",
                "https://bg.autodata24.com/i/audi/rs7/rs-7-sportback-4g/large/4b093ebf18151e547bcfda5e637bbcb9.jpg",
                "https://bg.autodata24.com/i/audi/rs7/rs-7-sportback-4g/large/c1502a20c5d7810882332cbf39fa5cbc.jpg",
                "https://bg.autodata24.com/i/audi/rs7/rs-7-sportback-4g/large/5b60bfe59876406953fded62fa014e90.jpg",

                "https://bg.autodata24.com/i/mercedes-benz/s-klasse/s-klasse-vi-w222-c217/large/8a512208f77b64ba07190e7b25e97c7a.jpg",
                "https://bg.autodata24.com/i/mercedes-benz/s-klasse/s-klasse-vi-w222-c217/large/c8eb481aaf462584aaf6b4be638355d2.jpg",
                "https://bg.autodata24.com/i/mercedes-benz/s-klasse/s-klasse-vi-w222-c217/large/68a5de22f0f5d45cf3670a154011f394.jpg",
                "https://bg.autodata24.com/i/mercedes-benz/s-klasse/s-klasse-vi-w222-c217/large/cb70d7936d0c9d620fea9d9d6dd2f44e.jpg",

                "https://bg.autodata24.com/i/bmw/m3/bmw-v-f80/large/953bcb9191bbe673ce1d210545ae721d.jpg",
                "https://bg.autodata24.com/i/bmw/m3/bmw-v-f80/large/0b62907693cf1aa1c9576ab92bf7e02f.jpg",
                "https://bg.autodata24.com/i/bmw/m3/bmw-v-f80/large/d6f9727a89ff6ecf6c3bb82de31a1934.jpg",
                "https://bg.autodata24.com/i/bmw/m3/bmw-v-f80/large/4ec24b153ea8c310bcfa517a52545e1d.jpg",

                "https://bg.autodata24.com/i/bmw/m5/m5-f10/large/fd3db2e8917ab0938c3c6db4fbfb4519.jpg",
                "https://bg.autodata24.com/i/bmw/m5/m5-f10/large/2ab6aee51f14e4916d1c71dfa31d6a25.jpg",
                "https://bg.autodata24.com/i/bmw/m5/m5-f10/large/1c2e122f204fa3462b8236ecfb23b9f7.jpg",

                "https://bg.autodata24.com/i/audi/rs6/rs6-c7/large/bc607798eb3d18141e696a0efaa9af48.jpg",
                "https://bg.autodata24.com/i/audi/rs6/rs6-c7/large/b49e953050c30af263882210b33e9560.jpg",
                "https://bg.autodata24.com/i/audi/rs6/rs6-c7/large/e20a62a75dd86809d780e9be2c24d869.jpg",
                "https://bg.autodata24.com/i/audi/rs6/rs6-c7/large/32feebdcfd9399361784d3b1c29850f4.jpg",

                "https://bg.autodata24.com/i/mercedes-benz/g-klasse/g-classe-w464/large/6b222dc469f717318595308f2cd3ea6d.jpg",
                "https://bg.autodata24.com/i/mercedes-benz/g-klasse/g-classe-w464/large/af1012dc200da711e662ee5a623d276b.jpg",
                "https://bg.autodata24.com/i/mercedes-benz/g-klasse/g-classe-w464/large/5b5c63bb7413526f64a69c5999289685.jpg",
                "https://bg.autodata24.com/i/mercedes-benz/g-klasse/g-classe-w464/large/af42812abd7dbb4ff8d5581071b8aad3.jpg",
            };

            foreach (var link in links)
            {
                await service.UploadAsync(link);
            }
        }
    }
}
