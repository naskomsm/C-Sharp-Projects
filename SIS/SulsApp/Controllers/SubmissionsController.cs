namespace SulsApp.Controllers
{
    using SIS.HTTP.Response;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attribues;
    using SulsApp.Services;
    using SulsApp.ViewModels.Submissions;

    public class SubmissionsController : Controller
    {
        private readonly ISubmissionsService submissionsService;
        private readonly IProblemsService problemsService;

        public SubmissionsController(ISubmissionsService submissionsService, IProblemsService problemsService)
        {
            this.submissionsService = submissionsService;
            this.problemsService = problemsService;
        }

        public HttpResponse Create(string id)
        {
            var problem = this.problemsService.GetProblemById(id);

            var model = new SubmissionCreateViewModel()
            {
                Name = problem.Name,
                ProblemId = problem.Id
            };

            return this.View(model);
        }

        [HttpPost]
        public HttpResponse Create(string code, string ProblemId)
        {
            if (string.IsNullOrEmpty(code) || string.IsNullOrWhiteSpace(code))
            {
                return this.Redirect("/Create");
            }

            submissionsService.Create(code, ProblemId, this.User);

            return this.Redirect("/");
        }

        public HttpResponse Delete(string id)
        {
            this.submissionsService.Delete(id);

            return this.Redirect("/");
        }
    }
}
