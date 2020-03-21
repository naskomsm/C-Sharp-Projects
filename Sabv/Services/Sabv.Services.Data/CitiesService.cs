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
            if (name == null)
            {
                throw new ArgumentNullException("Name cannot be null.");
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

        public IEnumerable<City> GetAll()
        {
            return this.citiesRepo.All().OrderBy(x => x.Name).ToList();
        }

        public City GetCityByName(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("Name cannot be null.");
            }

            return this.citiesRepo.All().FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
        }
    }
}
