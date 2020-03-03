namespace Sabv.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Sabv.Data.Common.Repositories;
    using Sabv.Data.Models.Images;

    public class ImageService : IImageService
    {
        private readonly IRepository<Image> imageRepo;

        public ImageService(IRepository<Image> imageRepo)
        {
            this.imageRepo = imageRepo;
        }

        public async Task AddAsync(Image image)
        {
            await this.imageRepo.AddAsync(image);
            await this.imageRepo.SaveChangesAsync();
        }

        public IEnumerable<Image> GetAll()
        {
            return this.imageRepo.All();
        }

        public Image GetById(int id)
        {
            return this.imageRepo.All().FirstOrDefault(x => x.Id == id);
        }
    }
}
