namespace Sabv.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Sabv.Data.Common.Repositories;
    using Sabv.Data.Models;
    using Sabv.Services.Mapping;

    public class CitiesService : ICitiesService
    {
        private readonly IDeletableEntityRepository<City> citiesRepo;

        public CitiesService(IDeletableEntityRepository<City> citiesRepo)
        {
            this.citiesRepo = citiesRepo;
        }

        public async Task AddAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Name cannot be null or empty.");
            }

            await this.citiesRepo.AddAsync(new City()
            {
                Name = name,
            });

            await this.citiesRepo.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.citiesRepo.All().OrderBy(x => x.Name).To<T>().ToList();
        }

        public IEnumerable<T> GetAllAsNoTracking<T>()
        {
            return this.citiesRepo.AllAsNoTracking().OrderBy(x => x.Name).To<T>().ToList();
        }

        public City GetCityByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Name cannot be null or empty.");
            }

            return this.citiesRepo.All().FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
        }
    }
}
