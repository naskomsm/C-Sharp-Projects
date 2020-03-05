namespace Sabv.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using Sabv.Data.Models.Images;

    public interface ICloudinaryService
    {
        Task<ICollection<Image>> UploadAsync(ICollection<IFormFile> files);

        Task<Image> UploadAsync(string url);
    }
}
