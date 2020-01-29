namespace SulsApp.Controllers
{
    using SIS.HTTP;
    using SIS.HTTP.Response;
    using SIS.MvcFramework;
    using Suls.Services;
    using Suls.Services.Models.Users;

    public class UsersController : Controller
    {
        private IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login(HttpRequest request)
        {
            return this.View();
        }

        public HttpResponse Register(HttpRequest request)
        {
            return this.View();
        }

        public HttpResponse DoLogin(HttpRequest request)
        {
            return this.View("IndexLoggedIn");
        }

        public HttpResponse DoRegister(HttpRequest request)
        {
            var model = new RegisterUserServiceModel()
            {
                Email = request.FormData["email"],
                Password = request.FormData["password"],
                Username = request.FormData["username"],
            };

            usersService.Register(model);

            return new RedirectResponse("/");
        }
    }
}
