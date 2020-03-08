namespace Sabv.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Sabv.Data.Models;

    public interface IModelsService
    {
        IEnumerable<T> GetAll<T>();

        Task AddAsync(string name, Make make);

        Model GetModelByName(string name);

        IEnumerable<Model> GetAll();
    }
}
