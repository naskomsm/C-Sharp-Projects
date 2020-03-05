namespace Sabv.Services.Data.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Http;
    using Sabv.Common;
    using Sabv.Data.Models.Images;

    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary cloudinary;
        private readonly IImageService imageService;

        public CloudinaryService(Cloudinary cloudinary, IImageService imageService)
        {
            this.cloudinary = cloudinary;
            this.imageService = imageService;
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
                var url = result.Uri.ToString();
                var urlDb = url.Replace(GlobalConstants.BaseCloudinaryLink, string.Empty);

                var image = new Image()
                {
                    CreatedOn = DateTime.UtcNow,
                    IsDeleted = false,
                    Url = urlDb,
                };

                await this.imageService.AddAsync(image);

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
            var resultUrl = result.Uri.ToString();
            var urlDb = resultUrl.Replace(GlobalConstants.BaseCloudinaryLink, string.Empty);

            var image = new Image()
            {
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
                Url = urlDb,
            };

            await this.imageService.AddAsync(image);

            return image;
        }
    }
}
