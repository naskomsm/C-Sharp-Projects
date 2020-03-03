namespace Sabv.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Sabv.Data.Common.Repositories;
    using Sabv.Data.Models.Categories;

    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> categoryRepo;

        public CategoryService(IRepository<Category> categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }

        public async Task AddAsync(Category category)
        {
            await this.categoryRepo.AddAsync(category);
            await this.categoryRepo.SaveChangesAsync();
        }

        public IEnumerable<Category> GetAll()
        {
            return this.categoryRepo.All();
        }

        public Category GetById(int id)
        {
            return this.categoryRepo.All().FirstOrDefault(x => x.Id == id);
        }
    }
}
