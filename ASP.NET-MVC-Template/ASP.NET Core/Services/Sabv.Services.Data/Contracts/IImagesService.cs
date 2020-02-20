namespace Sabv.Services.Data.Contracts
{
    public interface IImagesService
    {
        void UploadFileFromUrl(string url);

        void UploadFileFromLocal(string fileName);
    }
}
