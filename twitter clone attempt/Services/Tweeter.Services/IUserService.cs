namespace Tweeter.Services
{
    using Tweeter.Services.Models.User;

    public interface IUserService
    {
        bool Exists(int id);

        void Add(UserAddServiceModel model);

        bool Remove(int id);
    }
}
