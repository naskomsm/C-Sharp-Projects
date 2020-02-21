namespace Sabv.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Sabv.Common;
    using Sabv.Data.Common.Repositories;
    using Sabv.Data.Models;
    using Sabv.Services.Data.Contracts;
    using Sabv.Web.ViewModels.Posts;

    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<Post> postRepository;

        public PostsService(IDeletableEntityRepository<Post> postRepository)
        {
            this.postRepository = postRepository;
        }

        public async Task AddPost()
        {
            throw new System.NotImplementedException();
        }

        public ICollection<PostViewModel> GetAllPosts()
        {
            return this.postRepository
                .All()
                .Select(x => new PostViewModel()
                {
                    CreatedOn = x.CreatedOn.ToString(),
                    ImageUrl = GlobalConstants.CloudinaryLinkWithoutSuffix + x.Images.FirstOrDefault().Url,
                    MainInfo = x.MainInfo,
                    Mileage = x.MainInfo.Mileage,
                    Name = x.Name,
                    Price = x.Price,
                })
                .ToList();
        }
    }
}
