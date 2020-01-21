namespace Tweeter.Services
{
    using Tweeter.Services.Models.Picture;

    public interface IPictureService
    {
        bool Exists(int id);

        void Add(PictureAddServiceModel model);

        bool Remove(int id);
    }
}
