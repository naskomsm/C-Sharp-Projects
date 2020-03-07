namespace Sabv.Services.Data
{
    using Sabv.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMakesService
    {
        IEnumerable<T> GetAll<T>();

        Make GetMakeByName(string name);

        IEnumerable<Make> GetAll();

        Task AddAsync(string name);
    }
}
