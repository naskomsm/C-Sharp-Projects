namespace Sabv.Services.Data
{
    using System;
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
            if (name == null || name.Length == 0)
            {
                throw new ArgumentNullException("Name cannot be null or empty.");
            }

            if (this.makesRepo.All().Any(x => x.Name == name))
            {
                throw new ArgumentException("Make with given name exists");
            }

            await this.makesRepo.AddAsync(new Make()
            {
                Name = name,
            });

            await this.makesRepo.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.makesRepo.All().OrderBy(x => x.Name).To<T>().ToList();
        }

        public IEnumerable<T> GetAllAsNoTracking<T>()
        {
            return this.makesRepo.AllAsNoTracking().OrderBy(x => x.Name).To<T>().ToList();
        }

        public Make GetMakeById(int id)
        {
            var entity = this.makesRepo.All().FirstOrDefault(x => x.Id == id);

            if (entity == null)
            {
                throw new ArgumentNullException("Cannot find make with given id.");
            }

            return entity;
        }

        public Make GetMakeByName(string name)
        {
            var entity = this.makesRepo.All().FirstOrDefault(x => x.Name.ToLower() == name.ToLower());

            if (entity == null)
            {
                throw new ArgumentNullException("Cannot find make with given name.");
            }

            return entity;
        }
    }
}
