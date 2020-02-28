namespace Sabv.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Sabv.Data.Models;
    using Sabv.Services.Models.Posts;
    using Sabv.Web.ViewModels.Posts;

    public interface IPostsService
    {
        ICollection<Post> GetAllPosts();

        // TODO:
        Task AddPostAsync(AddPostModel model);

        Task<DetailsViewModel> GetDetailsAsync(string id);
    }
}
