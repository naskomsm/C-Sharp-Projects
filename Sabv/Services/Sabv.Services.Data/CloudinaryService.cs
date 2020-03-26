namespace Sabv.Services.Data
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Http;
    using Sabv.Data.Models;

    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary cloudinary;
        private readonly IImagesService imagesService;

        public CloudinaryService(Cloudinary cloudinary, IImagesService imagesService)
        {
            this.cloudinary = cloudinary;
            this.imagesService = imagesService;
        }

        public async Task<ICollection<Image>> UploadAsync(ICollection<IFormFile> files)
        {
            var imagesToReturn = new List<Image>();

            foreach (var file in files)
            {
                byte[] destinationImage;

                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                destinationImage = memoryStream.ToArray();

                using var destinationStream = new MemoryStream(destinationImage);
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.Name, destinationStream),
                };

                var result = await this.cloudinary.UploadAsync(uploadParams);
                var url = result.SecureUri.ToString();

                var image = new Image()
                {
                    Url = url,
                };

                await this.imagesService.AddAsync(url);

                imagesToReturn.Add(image);
            }

            return imagesToReturn;
        }

        public async Task<Image> UploadAsync(string url)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(url),
            };

            var result = await this.cloudinary.UploadAsync(uploadParams);
            var urlToAdd = result.SecureUri.ToString();

            var image = new Image()
            {
                Url = urlToAdd,
            };

            await this.imagesService.AddAsync(urlToAdd);

            return image;
        }
    }
}
