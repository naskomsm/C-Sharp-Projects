namespace Sabv.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Sabv.Data.Common.Repositories;
    using Sabv.Data.Models;
    using Sabv.Services.Mapping;

    public class ColorService : IColorService
    {
        private readonly IDeletableEntityRepository<Color> colorRepo;

        public ColorService(IDeletableEntityRepository<Color> colorRepo)
        {
            this.colorRepo = colorRepo;
        }

        public async Task AddAsync(string name)
        {
            await this.colorRepo.AddAsync(new Color()
            {
                Name = name,
            });
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.colorRepo.All().OrderBy(x => x.Name).To<T>().ToList();
        }

        public IEnumerable<Color> GetAll()
        {
            return this.colorRepo.All().OrderBy(x => x.Name).ToList();
        }

        public Color GetColorByName(string name)
        {
            return this.colorRepo.All().FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
        }
    }
}
