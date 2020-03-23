namespace Sabv.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Sabv.Common;
    using Sabv.Services.Data;
    using Sabv.Services.Messaging;
    using Sabv.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IPostsService postsService;
        private readonly ICategoriesService categoriesService;
        private readonly IImagesService imagesService;
        private readonly IEmailSender emailSender;

        public HomeController(
            IPostsService postsService,
            ICategoriesService categoriesService,
            IImagesService imagesService,
            IEmailSender emailSender)
        {
            this.postsService = postsService;
            this.categoriesService = categoriesService;
            this.imagesService = imagesService;
            this.emailSender = emailSender;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new IndexViewModel()
            {
                Categories = this.categoriesService.GetAll(),
                FirstThreeImages = this.imagesService.GetAll().Take(3),
                Posts = this.postsService.GetAll().Take(6),
            };

            return this.View(model);
        }

        [HttpGet]
        public IActionResult About()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult ChatView()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> SendEmailAsync(EmailContactInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("About", "Home");
            }

            await this.emailSender.SendEmailAsync(inputModel.From, inputModel.FromName, GlobalConstants.SystemEmail, inputModel.Subject, inputModel.Message);
            return this.RedirectToAction("Index", "Home");
        }
    }
}
