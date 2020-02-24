namespace Sabv.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Sabv.Data.Models;

    public interface IImagesService
    {
        ICollection<Image> GetAll();

        Task<string> UploadFileAsync(string url);

        Task AddToBaseAsync(string url);
    }
}
