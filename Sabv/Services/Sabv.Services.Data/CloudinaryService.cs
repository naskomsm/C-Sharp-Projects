namespace Sabv.Services.Data
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Http;
    using Sabv.Common;

    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary cloudinary;
        private readonly IImagesService imagesService;

        public CloudinaryService(Cloudinary cloudinary, IImagesService imagesService)
        {
            this.cloudinary = cloudinary;
            this.imagesService = imagesService;
        }

        public async Task UploadAsync(ICollection<IFormFile> files)
        {
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

                await this.imagesService.AddAsync(urlDb);
            }
        }

        public async Task UploadAsync(string url)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(url),
            };

            var result = await this.cloudinary.UploadAsync(uploadParams);
            var resultUrl = result.SecureUri.ToString();
            var urlDb = resultUrl.Replace(GlobalConstants.BaseCloudinaryLink, string.Empty);

            await this.imagesService.AddAsync(urlDb);
        }
    }
}
