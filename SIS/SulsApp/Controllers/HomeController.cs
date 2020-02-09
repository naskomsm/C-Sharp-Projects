namespace SulsApp.Controllers
{
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attribues;
    using SIS.HTTP.Response;
    using SulsApp.ViewModels.Home;
    using SulsApp.Services;

    public class HomeController : Controller
    {
        private readonly IProblemsService problemsService;

        public HomeController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                var allProblems = this.problemsService.GetAllProblems();
                
                var model = new IndexLoggedInViewModel()
                {
                    Problems = allProblems
                };

                return this.View(model, "IndexLoggedIn");
            }

            return this.View();
        }
    }
}
