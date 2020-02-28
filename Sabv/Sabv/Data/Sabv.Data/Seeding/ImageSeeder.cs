namespace Sabv.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using Sabv.Common;
    using Sabv.Data.Models;
    using Sabv.Services.Data.Contracts;

    public class ImageSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var imageService = serviceProvider.GetRequiredService<IImagesService>();
            var postsService = serviceProvider.GetRequiredService<IPostsService>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await SeedImageAsync(imageService, postsService, userManager);
        }

        private static async Task SeedImageAsync(IImagesService imagesService, IPostsService postsService, UserManager<ApplicationUser> userManager)
        {
            // user - 0, bmw - 1, audi - 2
            var urls = new List<string>()
            {
                "https://www.kindpng.com/picc/m/24-248729_stockvader-predicted-adig-user-profile-image-png-transparent.png",
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

            var bmwPost = postsService
                .GetAllPosts()
                .Where(x => x.Name.ToLower() == "bmw m5 f90")
                .FirstOrDefault();

            var audiPost = postsService
               .GetAllPosts()
               .Where(x => x.Name.ToLower() == "audi rs7")
               .FirstOrDefault();

            await imagesService.AddToBaseAsync(trimmedUrls[0], null);
            await imagesService.AddToBaseAsync(trimmedUrls[1], bmwPost.Id);
            await imagesService.AddToBaseAsync(trimmedUrls[2], audiPost.Id);

            var bmwImage = imagesService.GetAll().FirstOrDefault(x => x.PostId == bmwPost.Id);
            var audiImage = imagesService.GetAll().FirstOrDefault(x => x.PostId == audiPost.Id);
            var userImage = imagesService.GetAll().FirstOrDefault(x => x.PostId == null);

            var allUsers = userManager.Users.ToList();

            foreach (var user in allUsers)
            {
                user.ImageId = userImage.Id;
                user.Image = userImage;
            }
        }
    }
}
