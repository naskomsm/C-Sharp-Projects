namespace Sabv.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Sabv.Data.Models;

    public interface IVehicleCategoriesService
    {
        IEnumerable<T> GetAll<T>();

        VehicleCategory GetVehicleCategoryByName(string name);

        IEnumerable<VehicleCategory> GetAll();

        Task AddAsync(string name);
    }
}
