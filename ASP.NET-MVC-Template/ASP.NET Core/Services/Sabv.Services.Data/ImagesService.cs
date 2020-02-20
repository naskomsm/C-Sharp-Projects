namespace Sabv.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Sabv.Data.Common.Repositories;
    using Sabv.Data.Models;
    using Sabv.Services.Data.Contracts;

    public class ImagesService : IImagesService
    {
        private readonly Cloudinary cloudinaryUtility;
        private readonly IDeletableEntityRepository<Image> imageRepository;

        public ImagesService(Cloudinary cloudinaryUtility, IDeletableEntityRepository<Image> imageRepository)
        {
            this.cloudinaryUtility = cloudinaryUtility;
            this.imageRepository = imageRepository;
        }

        public async Task AddToBase(string url)
        {
            var image = new Image()
            {
                CreatedOn = DateTime.Now,
                IsDeleted = false,
                Url = url,
            };

            await this.imageRepository.AddAsync(image);
            await this.imageRepository.SaveChangesAsync();
        }

        public async Task<string> UploadFile(string url)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(url),
            };

            var uploadResult = await this.cloudinaryUtility.UploadAsync(uploadParams);

            return uploadResult.Uri.ToString();
        }
    }
}
