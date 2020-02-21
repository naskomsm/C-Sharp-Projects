namespace Sabv.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Sabv.Web.ViewModels.Posts;

    public interface IPostsService
    {
        ICollection<PostViewModel> GetAllPosts();

        // TODO:
        Task AddPost();
    }
}
