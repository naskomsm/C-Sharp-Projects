namespace Sabv.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Sabv.Data.Models;

    public interface IImagesService
    {
        IEnumerable<T> GetAll<T>();

        IEnumerable<Image> GetAll();

        Image GetImageByUrl(string dbUrl);

        Task AddAsync(string url);
    }
}
