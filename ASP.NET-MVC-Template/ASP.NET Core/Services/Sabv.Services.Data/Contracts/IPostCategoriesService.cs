namespace Sabv.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Sabv.Data.Models;
    using Sabv.Services.Models.PostCategories;

    public interface IPostCategoriesService
    {
        Task AddAsync(string name);

        Task<PostCategory> GetByIdAsync(string id);

        ICollection<PostCategoriesViewModel> GetAllCategories();

        ICollection<string> GetAllCategoriesNames();
    }
}
