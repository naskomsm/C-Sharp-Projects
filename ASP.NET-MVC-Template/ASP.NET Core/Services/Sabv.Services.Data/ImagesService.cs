namespace Sabv.Services.Data
{
    using System;

    using CloudinaryDotNet;
    using Sabv.Services.Data.Contracts;

    public class ImagesService : IImagesService
    {
        private readonly Cloudinary cloudinaryUtility;

        public ImagesService(Cloudinary cloudinaryUtility)
        {
            this.cloudinaryUtility = cloudinaryUtility;
        }

        public void UploadFileFromLocal(string fileName)
        {
            throw new NotImplementedException();
        }

        public void UploadFileFromUrl(string url)
        {
            throw new NotImplementedException();
        }
    }
}
