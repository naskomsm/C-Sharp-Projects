namespace Sabv.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Sabv.Data.Common.Repositories;
    using Sabv.Data.Models.Models;

    public class ModelsService : IModelsService
    {
        private readonly IRepository<Model> modelsRepo;

        public ModelsService(IRepository<Model> modelsRepo)
        {
            this.modelsRepo = modelsRepo;
        }

        public async Task AddAsync(Model model)
        {
            await this.modelsRepo.AddAsync(model);
            await this.modelsRepo.SaveChangesAsync();
        }

        public IEnumerable<Model> GetAll()
        {
            return this.modelsRepo.All();
        }

        public Model GetById(int id)
        {
            return this.modelsRepo.All().FirstOrDefault(x => x.Id == id);
        }
    }
}
