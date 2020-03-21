namespace Sabv.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Sabv.Data.Common.Repositories;
    using Sabv.Data.Models;
    using Sabv.Services.Mapping;

    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoryRepo;

        public CategoriesService(IDeletableEntityRepository<Category> categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }

        public async Task AddAsync(string name, Image image, string description)
        {
            if (name == null)
            {
                throw new ArgumentNullException("Name cannot be null");
            }

            await this.categoryRepo.AddAsync(new Category()
            {
                Name = name,
                Image = image,
                ImageId = image.Id,
                Description = description,
            });

            await this.categoryRepo.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.categoryRepo.All().OrderBy(x => x.Name).To<T>().ToList();
        }

        public IEnumerable<Category> GetAll()
        {
            return this.categoryRepo.All().OrderBy(x => x.Name).ToList();
        }

        public Category GetCategoryByName(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("Name cannot be null");
            }

            return this.categoryRepo.All().FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
        }
    }
}
