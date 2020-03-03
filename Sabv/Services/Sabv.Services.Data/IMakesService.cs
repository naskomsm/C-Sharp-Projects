namespace Sabv.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Sabv.Data.Models.Makes;
    using Sabv.Data.Models.Models;

    public interface IMakesService
    {
        IEnumerable<Make> GetAll();

        Make GetById(int id);

        IEnumerable<Model> GetAllModels(int makeId);

        Task AddAsync(Make make);
    }
}
