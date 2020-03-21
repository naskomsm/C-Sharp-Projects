namespace Sabv.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Sabv.Data.Common.Repositories;
    using Sabv.Data.Models;
    using Sabv.Services.Mapping;

    public class FavouritesService : IFavouritesService
    {
        private readonly IDeletableEntityRepository<Favourite> favouritesRepo;

        public FavouritesService(IDeletableEntityRepository<Favourite> favouritesRepo)
        {
            this.favouritesRepo = favouritesRepo;
        }

        public async Task AddAsync(int postId, string userId)
        {
            if (this.favouritesRepo.All().Any(x => x.PostId == postId && x.UserId == userId))
            {
                throw new ArgumentException("This post is already in favourites.");
            }

            await this.favouritesRepo.AddAsync(new Favourite()
            {
                PostId = postId,
                UserId = userId,
            });

            await this.favouritesRepo.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllUserFavourites<T>(string userId)
        {
            return this.favouritesRepo.All().Where(x => x.UserId == userId).To<T>().ToList();
        }

        public IEnumerable<Favourite> GetAllUserFavourites(string userId)
        {
            return this.favouritesRepo.All().Where(x => x.UserId == userId).ToList();
        }

        public async Task Remove(int postId, string userId)
        {
            var entity = this.favouritesRepo.All().FirstOrDefault(x => x.PostId == postId && x.UserId == userId);

            if (entity == null)
            {
                throw new ArgumentNullException("Entity cannot be null.");
            }

            this.favouritesRepo.Delete(entity);
            await this.favouritesRepo.SaveChangesAsync();
        }
    }
}
