namespace Sabv.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Sabv.Data.Models.Categories;

    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();

        Category GetById(int id);

        Task AddAsync(Category category);
    }
}
