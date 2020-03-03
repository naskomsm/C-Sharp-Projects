namespace Sabv.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Sabv.Data.Common.Repositories;
    using Sabv.Data.Models.Categories;

    public class VehicleCategoryService : IVehicleCategoryService
    {
        private readonly IRepository<VehicleCategory> vehicleRepo;

        public VehicleCategoryService(IRepository<VehicleCategory> vehicleRepo)
        {
            this.vehicleRepo = vehicleRepo;
        }

        public async Task AddAsync(VehicleCategory category)
        {
            await this.vehicleRepo.AddAsync(category);
            await this.vehicleRepo.SaveChangesAsync();
        }

        public IEnumerable<VehicleCategory> GetAll()
        {
            return this.vehicleRepo.All();
        }

        public VehicleCategory GetById(int id)
        {
            return this.vehicleRepo.All().FirstOrDefault(x => x.Id == id);
        }
    }
}
