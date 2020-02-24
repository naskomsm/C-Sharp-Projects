namespace Sabv.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;
    using Sabv.Common;
    using Sabv.Services.Data.Contracts;

    public class ImageSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var imageService = serviceProvider.GetRequiredService<IImagesService>();
            var postsService = serviceProvider.GetRequiredService<IPostsService>();
            await SeedImageAsync(imageService, postsService);
        }

        private static async Task SeedImageAsync(IImagesService imagesService, IPostsService postsService)
        {
            var urls = new List<string>()
            {
                "https://ag-spots-2019.o.auroraobjects.eu/2019/01/08/other/2880-1800-crop-bmw-m5-f90-competition-c301108012019101449_1.jpg",
                "https://promosale.bg/resources/dsc0003.jpg",
            };

            var trimmedUrls = new List<string>();

            foreach (var path in urls)
            {
                var url = await imagesService.UploadFileAsync(path);
                url = url.Substring(GlobalConstants.CloudinaryLinkLengthWithoutSuffix);
                trimmedUrls.Add(url);
            }

            foreach (var url in trimmedUrls)
            {
                await imagesService.AddToBaseAsync(url);
            }

            var bmwImage = imagesService.GetAll().ToArray()[1];
            bmwImage.PostId = postsService.GetAllPosts().ToArray()[1].Id;

            var audiImage = imagesService.GetAll().ToArray()[2];
            audiImage.PostId = postsService.GetAllPosts().ToArray()[2].Id;
        }
    }
}
