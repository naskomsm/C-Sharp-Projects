namespace Sabv.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Sabv.Data.Common.Repositories;
    using Sabv.Data.Models;
    using Sabv.Services.Mapping;

    public class VehicleCategoriesService : IVehicleCategoriesService
    {
        private readonly IDeletableEntityRepository<VehicleCategory> vehicleCategoriesRepo;

        public VehicleCategoriesService(IDeletableEntityRepository<VehicleCategory> vehicleCategoriesRepo)
        {
            this.vehicleCategoriesRepo = vehicleCategoriesRepo;
        }

        public async Task AddAsync(string name)
        {
            await this.vehicleCategoriesRepo.AddAsync(new VehicleCategory()
            {
                Name = name,
            });
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.vehicleCategoriesRepo.All().OrderBy(x => x.Name).To<T>().ToList();
        }

        public IEnumerable<VehicleCategory> GetAll()
        {
            return this.vehicleCategoriesRepo.All().OrderBy(x => x.Name).ToList();
        }

        public VehicleCategory GetVehicleCategoryByName(string name)
        {
            return this.vehicleCategoriesRepo.All().FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
        }
    }
}
