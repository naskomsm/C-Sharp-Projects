namespace Sabv.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Sabv.Data.Models;

    public interface ICitiesService
    {
        IEnumerable<T> GetAll<T>();

        IEnumerable<T> GetAllAsNoTracking<T>();

        City GetCityByName(string name);

        Task AddAsync(string name);
    }
}
