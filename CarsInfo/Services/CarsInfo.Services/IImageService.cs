namespace CarsInfo.Services
{
    using CarsInfo.Services.Models.Image;

    public interface IImageService
    {
        bool Exists(int id);

        void Add(ImageAddServiceModel model);

        bool Remove(int id);
    }
}
