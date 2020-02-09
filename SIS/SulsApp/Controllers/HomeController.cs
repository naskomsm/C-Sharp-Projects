namespace SulsApp.Controllers
{
    using System;
    using SIS.MvcFramework;
    using SulsApp.ViewModels.Home;
    using SIS.MvcFramework.Attribues;
    using SIS.HTTP.Response;

    public class HomeController : Controller
    {
        [HttpGet("/")]
        public HttpResponse Index()
        {
            var viewModel = new IndexViewModel
            {
                Message = "Welcome to SULS Platform!",
                Year = DateTime.UtcNow.Year,
            };

            return this.View(viewModel);
        }
    }
}
