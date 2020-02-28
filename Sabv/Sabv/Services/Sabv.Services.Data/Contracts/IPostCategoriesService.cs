namespace Sabv.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Sabv.Data.Models;

    public interface IPostCategoriesService
    {
        Task AddAsync(string name);

        Task<PostCategory> GetByIdAsync(string id);

        ICollection<PostCategory> GetAllCategories();

        ICollection<string> GetAllCategoriesNames();
    }
}
