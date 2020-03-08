namespace Sabv.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Sabv.Data.Models;

    public interface ICategoriesService
    {
        IEnumerable<T> GetAll<T>();

        IEnumerable<Category> GetAll();

        Category GetCategoryByName(string name);

        Task AddAsync(string name, Image image);
    }
}
