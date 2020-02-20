namespace Sabv.Services.Data.Contracts
{
    using System.Threading.Tasks;

    public interface IImagesService
    {
        Task<string> UploadFile(string url);

        Task AddToBase(string url);
    }
}
