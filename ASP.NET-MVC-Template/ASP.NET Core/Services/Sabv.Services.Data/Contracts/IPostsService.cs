namespace Sabv.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Sabv.Services.Models.Posts;
    using Sabv.Web.ViewModels.Posts;

    public interface IPostsService
    {
        ICollection<PostViewModel> GetAllPosts();

        // TODO:
        Task AddPost();

        Task<PostDetailsModel> GetDetailsAsync(string id);
    }
}
