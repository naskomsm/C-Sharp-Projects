namespace Sabv.Services.Data
{
    using Sabv.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICitiesService
    {
        IEnumerable<T> GetAll<T>();

        IEnumerable<City> GetAll();

        Task AddAsync(string name);
    }
}
