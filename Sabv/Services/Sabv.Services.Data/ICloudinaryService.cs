namespace Sabv.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    public interface ICloudinaryService
    {
        Task UploadAsync(ICollection<IFormFile> files);

        Task UploadAsync(string url);
    }
}
