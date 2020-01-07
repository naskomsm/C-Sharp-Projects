namespace CarsInfo.Services
{
    using CarsInfo.Services.Models.User;

    public interface IUserService
    {
        bool VerifyUser(string email, string password);

        void Register(UserAddServiceModel model);

        bool Exists(int userId);

        UserGetServiceModel GetUserByEmail(string email);
    }
}
