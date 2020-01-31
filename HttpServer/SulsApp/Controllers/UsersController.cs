namespace SulsApp.Controllers
{
    using Microsoft.AspNetCore.Cryptography.KeyDerivation;
    using SIS.HTTP;
    using SIS.HTTP.Response;
    using SIS.MvcFramework;
    using Suls.Services;
    using Suls.Services.Models.Users;
    using System;
    using System.Security.Cryptography;

    public class UsersController : Controller
    {
        private IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
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
        public HttpResponse DoLogin(HttpRequest request)
        {
            // somehow match credentials ???


            return new RedirectResponse("/");
        }

        // POST
        public HttpResponse DoRegister(HttpRequest request)
        {
            var model = new RegisterUserServiceModel()
            {
                Email = request.FormData["email"],
                Password = this.HashPassword(request.FormData["password"]),
                Username = request.FormData["username"],
            };

            request.SessionData.Add(model.Username, model.Password);
            usersService.Register(model);

            return new RedirectResponse("/");
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
