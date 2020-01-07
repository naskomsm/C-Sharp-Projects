namespace CarsInfo.Services.Implementations
{
    using System.Linq;
    using CarsInfo.Data;
    using CarsInfo.Data.Models;
    using CarsInfo.Services.Models.User;

    public class UserService : IUserService
    {
        private readonly CarsInfoDbContext data;

        public UserService(CarsInfoDbContext data)
        {
            this.data = data;
        }

        public void Register(UserAddServiceModel model)
        {
            var hash = SecurePasswordHasher.Hash(model.Password);

            var user = new User()
            {
                Email = model.Email,
                Password = hash
            };

            this.data.Users.Add(user);
            this.data.SaveChanges();
        }

        public bool Exists(int userId)
        {
            return this.data.Users.Any(x => x.Id == userId);
        }

        public UserGetServiceModel GetUserByEmail(string email)
        {
            return this.data
                .Users
                .Where(x => x.Email == email)
                .Select(u => new UserGetServiceModel
                {
                    Id = u.Id,
                    Email = u.Email,
                    Password = u.Password
                })
                .FirstOrDefault();
        }

        // hashed, password from form
        public bool VerifyUser(string userPassord, string givenPassword)
        {
            return SecurePasswordHasher.Verify(givenPassword, userPassord);
        }
    }
}
