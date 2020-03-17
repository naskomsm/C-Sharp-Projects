namespace Sabv.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Sabv.Data.Models;

    public interface IFavouritesService
    {
        IEnumerable<T> GetAllUserFavourites<T>(string userId);

        IEnumerable<Favourite> GetAllUserFavourites(string userId);

        Task AddAsync(int postId, string userId);

        Task Remove(int postId, string userId);
    }
}
