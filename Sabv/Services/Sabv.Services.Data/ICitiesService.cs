namespace Sabv.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Sabv.Data.Models.Cities;

    public interface ICitiesService
    {
        IEnumerable<City> GetAll();

        City GetById(int id);

        Task AddAsync(City city);
    }
}
