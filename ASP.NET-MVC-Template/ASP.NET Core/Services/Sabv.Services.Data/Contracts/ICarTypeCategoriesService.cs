namespace Sabv.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Sabv.Data.Models;
    using Sabv.Services.Models.VehicleCategories;

    public interface ICarTypeCategoriesService
    {

        Task Add(string name);

        Task<VehicleCategory> GetById(string id);

        ICollection<VehicleCategoriesViewModel> GetAllCategories();
    }
}
