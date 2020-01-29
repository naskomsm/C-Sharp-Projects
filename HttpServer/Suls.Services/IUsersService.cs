namespace Suls.Services
{
    using Suls.Services.Models.Users;

    public interface IUsersService
    {
        void Login(LoginUserServiceModel model);

        void Register(RegisterUserServiceModel model);
    }
}
