namespace Sabv.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Sabv.Data.Models;

    public interface IVehicleCategoriesService
    {
        IEnumerable<T> GetAll<T>();

        VehicleCategory GetVehicleCategoryByName(string name);

        IEnumerable<T> GetAllAsNoTracking<T>();

        Task AddAsync(string name);
    }
}
