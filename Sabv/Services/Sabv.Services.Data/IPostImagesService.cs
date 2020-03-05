namespace Sabv.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Sabv.Data.Models.PostsImages;

    public interface IPostImagesService
    {
        IEnumerable<PostImage> GetAll();

        Task AddAsync(PostImage image);

        Task<bool> RemoveAsync(int postId, int imageId);
    }
}
