namespace Sabv.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Sabv.Data.Models.Posts;
    using Sabv.Web.ViewModels.Posts;

    public interface IPostsService
    {
        IEnumerable<Post> GetAll();

        Post GetById(int id);

        Task AddAsync(Post post);

        DetailsViewModel GetDetails(int id);

        IEnumerable<Post> GetLatestPosts();
    }
}
