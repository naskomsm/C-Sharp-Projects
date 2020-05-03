namespace Sabv.Services.Data
{
    using System;
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
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Name cannot be null or empty.");
            }

            await this.vehicleCategoriesRepo.AddAsync(new VehicleCategory()
            {
                Name = name,
            });

            await this.vehicleCategoriesRepo.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.vehicleCategoriesRepo.All().OrderBy(x => x.Name).To<T>().ToList();
        }

        public IEnumerable<T> GetAllAsNoTracking<T>()
        {
            return this.vehicleCategoriesRepo.AllAsNoTracking().OrderBy(x => x.Name).To<T>().ToList();
        }

        public VehicleCategory GetVehicleCategoryByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Name cannot be null or empty.");
            }

            return this.vehicleCategoriesRepo.All().FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
        }
    }
}
