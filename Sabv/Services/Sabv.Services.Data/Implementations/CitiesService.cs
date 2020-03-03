namespace Sabv.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Sabv.Data.Common.Repositories;
    using Sabv.Data.Models.Cities;

    public class CitiesService : ICitiesService
    {
        private readonly IRepository<City> cityRepo;

        public CitiesService(IRepository<City> cityRepo)
        {
            this.cityRepo = cityRepo;
        }

        public async Task AddAsync(City city)
        {
            await this.cityRepo.AddAsync(city);
            await this.cityRepo.SaveChangesAsync();
        }

        public IEnumerable<City> GetAll()
        {
            return this.cityRepo.All();
        }

        public City GetById(int id)
        {
            return this.cityRepo.All().FirstOrDefault(x => x.Id == id);
        }
    }
}
