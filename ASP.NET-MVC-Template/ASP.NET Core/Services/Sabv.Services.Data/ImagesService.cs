namespace Sabv.Services.Data
{
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Sabv.Services.Data.Contracts;

    public class ImagesService : IImagesService
    {
        private readonly Cloudinary cloudinaryUtility;

        public ImagesService(Cloudinary cloudinaryUtility)
        {
            this.cloudinaryUtility = cloudinaryUtility;
        }

        public async Task<string> UploadFile(string url)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(url),
            };

            var uploadResult = await this.cloudinaryUtility.UploadAsync(uploadParams);

            return uploadResult.Uri.ToString();
        }
    }
}
