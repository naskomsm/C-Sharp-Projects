namespace Sabv.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    using Sabv.Services.Data;
    using Sabv.Web.ViewModels;
    using Sabv.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IPostsService postsService;

        public HomeController(IPostsService postsService)
        {
            this.postsService = postsService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new IndexViewModel()
            {
                Posts = this.postsService.GetLatest<PostIndexViewModel>(6),
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
