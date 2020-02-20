namespace Sabv.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Sabv.Data.Models;
    using Sabv.Services.Models.PostCategories;

    public interface IPostCategoriesService
    {
        Task Add(string name);

        Task<PostCategory> GetById(string id);

        ICollection<PostCategoriesViewModel> GetAllCategories();

        ICollection<string> GetAllCategoriesNames();
    }
}
