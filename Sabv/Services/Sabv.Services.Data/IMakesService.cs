namespace Sabv.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Sabv.Data.Models;

    public interface IMakesService
    {
        IEnumerable<T> GetAll<T>();

        Make GetMakeByName(string name);

        Make GetMakeById(int id);

        IEnumerable<Make> GetAll();

        Task AddAsync(string name);
    }
}
