namespace Sabv.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Sabv.Data.Common.Repositories;
    using Sabv.Data.Models;
    using Sabv.Services.Mapping;

    public class MakesService : IMakesService
    {
        private readonly IDeletableEntityRepository<Make> makesRepo;

        public MakesService(IDeletableEntityRepository<Make> makesRepo)
        {
            this.makesRepo = makesRepo;
        }

        public async Task AddAsync(string name)
        {
            await this.makesRepo.AddAsync(new Make()
            {
                Name = name,
            });
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.makesRepo.All().OrderBy(x => x.Name).To<T>().ToList();
        }

        public IEnumerable<Make> GetAll()
        {
            return this.makesRepo.All().OrderBy(x => x.Name).ToList();
        }

        public Make GetMakeByName(string name)
        {
            return this.makesRepo.All().FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
        }
    }
}
