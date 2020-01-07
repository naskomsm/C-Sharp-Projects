namespace CarsInfo.Web.Controllers
{
    using CarsInfo.Services;
    using CarsInfo.Services.Models.User;
    using Microsoft.AspNetCore.Mvc;

    public class UserController : Controller
    {
        private readonly IUserService users;

        public UserController(IUserService users)
        {
            this.users = users;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserAddServiceModel model)
        {
            // validate
            this.users.Register(model);

            return RedirectToAction("Index", "Home");
        }
    }
}