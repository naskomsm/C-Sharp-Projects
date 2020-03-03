namespace Sabv.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Sabv.Data.Models.Images;

    public interface IImageService
    {
        IEnumerable<Image> GetAll();

        Image GetById(int id);

        Task AddAsync(Image image);
    }
}
