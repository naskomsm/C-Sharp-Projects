namespace Sabv.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Sabv.Data.Models;
    using Sabv.Services.Models.VehicleCategories;

    public interface IVehicleTypeCategoriesService
    {
        Task AddAsync(string name);

        Task<VehicleCategory> GetByIdAsync(string id);

        ICollection<VehicleCategoriesViewModel> GetAllCategories();

        ICollection<string> GetAllCategoriesNames();
    }
}
