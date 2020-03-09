namespace Sabv.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Sabv.Services.Data;
    using Sabv.Web.ViewModels;
    using Sabv.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IPostsService postsService;
        private readonly ICategoriesService categoriesService;
        private readonly IImagesService imagesService;

        public HomeController(IPostsService postsService, ICategoriesService categoriesService, IImagesService imagesService)
        {
            this.postsService = postsService;
            this.categoriesService = categoriesService;
            this.imagesService = imagesService;
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
