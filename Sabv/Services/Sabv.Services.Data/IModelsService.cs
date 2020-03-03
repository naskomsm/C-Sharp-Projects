namespace Sabv.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Sabv.Data.Models.Models;

    public interface IModelsService
    {
        IEnumerable<Model> GetAll();

        Model GetById(int id);

        Task AddAsync(Model model);
    }
}
