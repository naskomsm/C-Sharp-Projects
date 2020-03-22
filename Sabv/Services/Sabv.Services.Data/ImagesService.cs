namespace Sabv.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Sabv.Data.Common.Repositories;
    using Sabv.Data.Models;
    using Sabv.Services.Mapping;

    public class ImagesService : IImagesService
    {
        private readonly IDeletableEntityRepository<Image> imagesRepo;

        public ImagesService(IDeletableEntityRepository<Image> imagesRepo)
        {
            this.imagesRepo = imagesRepo;
        }

        public async Task AddAsync(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("Url cannot be null or empty.");
            }

            await this.imagesRepo.AddAsync(new Image()
            {
                Url = url,
            });

            await this.imagesRepo.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.imagesRepo.All().To<T>().ToList();
        }

        public IEnumerable<Image> GetAll()
        {
            return this.imagesRepo.All().ToList();
        }

        public Image GetImageByUrl(string dbUrl)
        {
            if (string.IsNullOrEmpty(dbUrl))
            {
                throw new ArgumentNullException("Url cannot be null or empty.");
            }

            return this.imagesRepo.All().FirstOrDefault(x => x.Url == dbUrl);
        }
    }
}
