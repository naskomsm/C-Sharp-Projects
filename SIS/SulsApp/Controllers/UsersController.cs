namespace SulsApp.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;
    using SulsApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;

    public class UsersController : Controller
    {
        private readonly ApplicationDbContext data;

        public UsersController(ApplicationDbContext data)
        {
            this.data = data;
        }

        // GET
        public HttpResponse Login(HttpRequest request)
        {
            return this.View();
        }

        // GET
        public HttpResponse Register(HttpRequest request)
        {
            return this.View();
        }

        // POST
        public HttpResponse DoRegister(HttpRequest request)
        {
            var user = new User()
            {
                Email = request.FormData["email"],
                Password = HashPassword(request.FormData["password"]),
                Username = request.FormData["username"]
            };

            this.data.Users.Add(user);
            this.data.SaveChanges();

            return this.View("../../../../../Views/Home/Index");
        }

        // POST
        public HttpResponse DoLogin(HttpRequest request)
        {
            var formUsername = request.FormData["username"];
            var formPassword = request.FormData["password"];

            if (VerifyUserCredentials(formUsername, formPassword))
            {
                return this.View("../../../../../Views/Users/LoginSuccesfull");
            }
            else
            {
                return this.View("../../../../../Views/Home/Index");
            }
        }

        private string HashPassword(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string savedPasswordHash = Convert.ToBase64String(hashBytes);

            return savedPasswordHash;
        }

        private bool VerifyUserCredentials(string username, string password)
        {
            string savedPasswordHash = this.data.Users.FirstOrDefault(u => u.Username == username).Password;
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
