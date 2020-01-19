namespace Tweeter.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Tweeter.Data;
    using Tweeter.Data.Models;
    using Tweeter.Services.Models.User;

    public class UserService : IUserService
    {
        private readonly TweeterDbContext data;

        public UserService(TweeterDbContext data)
        {
            this.data = data;
        }

        public void Add(UserAddServiceModel model)
        {
            if (!DataValidation.IsValid(model))
            {
                throw new ArgumentException("Invalid data.");
            }

            var user = new User()
            {
                Joined = model.Joined,
                Picture = model.Picture,
                PictureId = model.PictureId,
                Email = model.Email
            };

            this.data.Users.Add(user);
            this.data.SaveChanges();
        }

        public bool Exists(int id)
        {
            return this.data.Users.Any(x => x.Id == id);
        }

        public bool Remove(int id)
        {
            if (!this.data.Users.Any(x => x.Id == id))
            {
                return false;
            }

            var user = this.data.Users.FirstOrDefault(x => x.Id == id);
            this.data.Users.Remove(user);
            this.data.SaveChanges();

            return true;
        }

        public ICollection<string> UsersEmails()
        {
            return this.data.Users.Select(x => x.Email).ToList();
        }
    }
}
