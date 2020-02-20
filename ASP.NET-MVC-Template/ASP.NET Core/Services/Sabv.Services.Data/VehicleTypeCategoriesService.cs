namespace Sabv.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Sabv.Data.Common.Repositories;
    using Sabv.Data.Models;
    using Sabv.Services.Data.Contracts;
    using Sabv.Services.Models.VehicleCategories;

    public class VehicleTypeCategoriesService : IVehicleTypeCategoriesService
    {
        private readonly IDeletableEntityRepository<VehicleCategory> vehicleCategory;

        public VehicleTypeCategoriesService(IDeletableEntityRepository<VehicleCategory> vehicleCategory)
        {
            this.vehicleCategory = vehicleCategory;
        }

        public async Task Add(string name)
        {
            var entity = new VehicleCategory()
            {
                CreatedOn = DateTime.UtcNow,
                Name = name,
                IsDeleted = false,
            };

            await this.vehicleCategory.AddAsync(entity);
            await this.vehicleCategory.SaveChangesAsync();
        }

        public ICollection<VehicleCategoriesViewModel> GetAllCategories()
        {
            var all = this.vehicleCategory
                .All()
                .OrderBy(x => x.CreatedOn)
                .Select(x => new VehicleCategoriesViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .ToList();

            return all;
        }

        public ICollection<string> GetAllCategoriesNames()
        {
            return this.vehicleCategory
                .All()
                .Select(x => x.Name)
                .ToList();
        }

        public async Task<VehicleCategory> GetById(string id)
        {
            var entity = await this.vehicleCategory
                   .GetByIdWithDeletedAsync(id);

            return entity;
        }
    }
}
