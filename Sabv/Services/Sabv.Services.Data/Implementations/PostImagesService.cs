namespace Sabv.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Sabv.Data.Common.Repositories;
    using Sabv.Data.Models.PostsImages;

    public class PostImagesService : IPostImagesService
    {
        private readonly IRepository<PostImage> postImageRepo;

        public PostImagesService(IRepository<PostImage> postImageRepo)
        {
            this.postImageRepo = postImageRepo;
        }

        public async Task AddAsync(PostImage image)
        {
            await this.postImageRepo.AddAsync(image);
            await this.postImageRepo.SaveChangesAsync();
        }

        public IEnumerable<PostImage> GetAll()
        {
            return this.postImageRepo.All();
        }

        public async Task<bool> RemoveAsync(int postId, int imageId)
        {
            if (!this.postImageRepo.All().Any(x => x.ImageId == imageId && x.PostId == postId))
            {
                return false;
            }

            var entity = this.postImageRepo.All().FirstOrDefault(x => x.ImageId == imageId && x.PostId == postId);
            this.postImageRepo.Delete(entity);
            await this.postImageRepo.SaveChangesAsync();

            return true;
        }
    }
}
