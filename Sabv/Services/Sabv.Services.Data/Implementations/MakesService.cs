namespace Sabv.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Sabv.Data.Common.Repositories;
    using Sabv.Data.Models.Makes;
    using Sabv.Data.Models.Models;

    public class MakesService : IMakesService
    {
        private readonly IRepository<Make> makeRepo;

        public MakesService(IRepository<Make> makeRepo)
        {
            this.makeRepo = makeRepo;
        }

        public IEnumerable<Model> GetAllModels(int makeId)
        {
            return this.GetById(makeId).Models;
        }

        public IEnumerable<Make> GetAll()
        {
            return this.makeRepo.All();
        }

        public Make GetById(int id)
        {
            return this.makeRepo.All().FirstOrDefault(x => x.Id == id);
        }

        public async Task AddAsync(Make make)
        {
            await this.makeRepo.AddAsync(make);
            await this.makeRepo.SaveChangesAsync();
        }
    }
}
