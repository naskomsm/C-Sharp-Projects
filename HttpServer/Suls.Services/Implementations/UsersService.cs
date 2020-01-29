namespace Suls.Services.Implementations
{
    using Microsoft.AspNetCore.Cryptography.KeyDerivation;
    using Suls.Data;
    using Suls.Data.Models;
    using Suls.Services.Models.Users;
    using System;
    using System.Linq;
    using System.Security.Cryptography;
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
            throw new NotImplementedException();
        }

        public void Register(RegisterUserServiceModel model)
        {
            //validate passwords
            //register user in db

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
                Password = this.HashPassword(model.Password),
                Username = model.Username,
            };

            this.data.Users.Add(user);
            this.data.SaveChanges(); // make this async later
        }

        private bool IsValidEmail(string strIn)
        {
            return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
       
        private string HashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }
    }
}
