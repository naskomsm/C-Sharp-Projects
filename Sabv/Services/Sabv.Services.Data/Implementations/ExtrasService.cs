namespace Sabv.Services.Data.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Sabv.Data.Common.Repositories;
    using Sabv.Data.Models.Extras;

    public class ExtrasService : IExtrasService
    {
        private readonly IRepository<Comfort> comfortsRepo;
        private readonly IRepository<Other> othersRepo;
        private readonly IRepository<Exterior> exteriorsRepo;
        private readonly IRepository<Safety> safetiesRepo;

        public ExtrasService(
            IRepository<Comfort> comfortsRepo,
            IRepository<Other> othersRepo,
            IRepository<Exterior> exteriorsRepo,
            IRepository<Safety> safetiesRepo)
        {
            this.comfortsRepo = comfortsRepo;
            this.othersRepo = othersRepo;
            this.exteriorsRepo = exteriorsRepo;
            this.safetiesRepo = safetiesRepo;
        }

        public async Task AddComfortAsync(Comfort comfort)
        {
            await this.comfortsRepo.AddAsync(comfort);
            await this.comfortsRepo.SaveChangesAsync();
        }

        public async Task AddExteriorAsync(Exterior exterior)
        {
            await this.exteriorsRepo.AddAsync(exterior);
            await this.exteriorsRepo.SaveChangesAsync();
        }

        public async Task AddOtherAsync(Other other)
        {
            await this.othersRepo.AddAsync(other);
            await this.othersRepo.SaveChangesAsync();
        }

        public async Task AddSafetyAsync(Safety safety)
        {
            await this.safetiesRepo.AddAsync(safety);
            await this.safetiesRepo.SaveChangesAsync();
        }

        public IEnumerable<Comfort> GetAllComforts()
        {
            return this.comfortsRepo.All();
        }

        public IEnumerable<Exterior> GetAllExteriors()
        {
            return this.exteriorsRepo.All();
        }

        public IEnumerable<Other> GetAllOthers()
        {
            return this.othersRepo.All();
        }

        public IEnumerable<Safety> GetAllSafeties()
        {
            return this.safetiesRepo.All();
        }

        public Comfort GetByIdComfort(int id)
        {
            return this.comfortsRepo.All().FirstOrDefault(x => x.Id == id);
        }

        public Exterior GetByIdExterior(int id)
        {
            return this.exteriorsRepo.All().FirstOrDefault(x => x.Id == id);
        }

        public Other GetByIdOther(int id)
        {
            return this.othersRepo.All().FirstOrDefault(x => x.Id == id);
        }

        public Safety GetByIdSafety(int id)
        {
            return this.safetiesRepo.All().FirstOrDefault(x => x.Id == id);
        }
    }
}
