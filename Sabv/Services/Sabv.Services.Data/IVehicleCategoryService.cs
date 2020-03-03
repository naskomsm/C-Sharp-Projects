namespace Sabv.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Sabv.Data.Models.Categories;

    public interface IVehicleCategoryService
    {
        IEnumerable<VehicleCategory> GetAll();

        VehicleCategory GetById(int id);

        Task AddAsync(VehicleCategory category);
    }
}
