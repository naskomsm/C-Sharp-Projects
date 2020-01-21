namespace Tweeter.Services
{
    using System.Collections.Generic;
    using Tweeter.Services.Models.User;

    public interface IUserService
    {
        bool Exists(int id);

        void Add(UserAddServiceModel model);

        bool Remove(int id);

        UserInfoServiceModel GetUserByEmail(string email);

        ICollection<string> UsersEmails();

        ICollection<UserInfoServiceModel> GetAllUsers();
    }
}
