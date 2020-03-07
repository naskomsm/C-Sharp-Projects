namespace Sabv.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Sabv.Data.Models;
    using Sabv.Web.ViewModels.Posts;

    public interface IPostsService
    {
        IEnumerable<T> GetAll<T>();

        IEnumerable<T> GetLatest<T>(int postCount);

        IEnumerable<Post> GetAll();

        T GetDetails<T>(int id);

        IEnumerable<Post> Filter(PostDetailsInputModel inputModel);

        Task AddAsync(Post postToAdd);
    }
}
