namespace Suls.Services.Implementations
{
    using Suls.Data;
    using Suls.Data.Models;
    using Suls.Services.Models.Users;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext data;

        public UsersService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public void Login(LoginUserServiceModel model)
        {
            
        }

        public void Register(RegisterUserServiceModel model)
        {
            //validate passwords

            if(data.Users.Any(x => x.Username == model.Username))
            {
                // user is already registered
            }

            if(model.Username.Length < 5)
            {
                // invalid username
            }

            if (!IsValidEmail(model.Email))
            {
                // invalid email
            }

            var user = new User()
            {
                Email = model.Email,
                Password = model.Password,
                Username = model.Username,
            };

            this.data.Users.Add(user);
            this.data.SaveChanges(); // make this async later
        }

        private bool IsValidEmail(string strIn)
        {
            return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
    }
}
