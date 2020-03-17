namespace Sabv.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Sabv.Data.Common.Repositories;
    using Sabv.Data.Models;
    using Sabv.Services.Mapping;

    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> commentRepo;

        public CommentsService(IDeletableEntityRepository<Comment> commentRepo)
        {
            this.commentRepo = commentRepo;
        }

        public async Task<int> AddAsync(string content, ApplicationUser user, Post post)
        {
            var comment = new Comment()
            {
                Content = content,
                User = user,
                UserId = user.Id,
                Post = post,
                PostId = post.Id,
            };

            await this.commentRepo.AddAsync(comment);
            await this.commentRepo.SaveChangesAsync();

            return comment.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = this.commentRepo.All().FirstOrDefault(x => x.Id == id);
            this.commentRepo.Delete(entity);
            await this.commentRepo.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.commentRepo.All().To<T>().ToList();
        }

        public IEnumerable<Comment> GetAll()
        {
            return this.commentRepo.All().ToList();
        }

        public async Task Like(int id)
        {
            var comment = this.commentRepo.All().FirstOrDefault(x => x.Id == id);
            comment.Likes++;

            await this.commentRepo.SaveChangesAsync();
        }
    }
}
