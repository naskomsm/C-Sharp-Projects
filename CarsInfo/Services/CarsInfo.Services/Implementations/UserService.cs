namespace CarsInfo.Services.Implementations
{
    using System.Linq;
    using CarsInfo.Data;
    using CarsInfo.Data.Models;
    using CarsInfo.Services.Models.User;

    public class UserService
    {
        private readonly CarsInfoDbContext data;

        public UserService(CarsInfoDbContext data)
        {
            this.data = data;
        }

        public void Register(UserAddServiceModel model)
        {
            var user = new User()
            {
                Name = model.Name,
                Email = model.Email
            };

            this.data.Users.Add(user);
            this.data.SaveChanges();
        }

        public bool Exists(int userId)
        {
            return this.data.Users.Any(x => x.Id == userId);
        }

        public int GetIdByName(string name)
        {
            return this.data
                .Users
                .Where(x => x.Name == name)
                .Select(x => x.Id)
                .FirstOrDefault();
        }
    }
}
