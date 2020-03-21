namespace Sabv.Services.Data
{
    using System;
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
            if (string.IsNullOrEmpty(content))
            {
                throw new ArgumentNullException("Content cannot be null or empty.");
            }

            if (user == null)
            {
                throw new ArgumentNullException("User cannot be null.");
            }

            if (post == null)
            {
                throw new ArgumentNullException("Post cannot be null.");
            }

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

            if (entity == null)
            {
                throw new ArgumentNullException("Not existing entity with given id.");
            }

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

            if (comment == null)
            {
                throw new ArgumentNullException("Not existing comment with given id.");
            }

            comment.Likes++;

            await this.commentRepo.SaveChangesAsync();
        }
    }
}
