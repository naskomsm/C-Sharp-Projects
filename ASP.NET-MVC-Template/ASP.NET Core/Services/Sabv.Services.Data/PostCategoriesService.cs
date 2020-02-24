namespace Sabv.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Sabv.Data.Common.Repositories;
    using Sabv.Data.Models;
    using Sabv.Services.Data.Contracts;
    using Sabv.Services.Models.PostCategories;

    public class PostCategoriesService : IPostCategoriesService
    {
        private readonly IDeletableEntityRepository<PostCategory> postCategoryRepository;

        public PostCategoriesService(IDeletableEntityRepository<PostCategory> postCategoryRepository)
        {
            this.postCategoryRepository = postCategoryRepository;
        }

        public async Task AddAsync(string name)
        {
            var entity = new PostCategory()
            {
                Name = name,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
            };

            await this.postCategoryRepository.AddAsync(entity);
            await this.postCategoryRepository.SaveChangesAsync();
        }

        public ICollection<PostCategoriesViewModel> GetAllCategories()
        {
            // use mapper later
            var all = this.postCategoryRepository
                .All()
                .OrderBy(x => x.CreatedOn)
                .Select(x => new PostCategoriesViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .ToList();

            return all;
        }

        public ICollection<string> GetAllCategoriesNames()
        {
            return this.postCategoryRepository
                .All()
                .Select(x => x.Name)
                .ToList();
        }

        public async Task<PostCategory> GetByIdAsync(string id)
        {
            var entity = await this.postCategoryRepository.GetByIdWithDeletedAsync(id);
            return entity;
        }
    }
}
