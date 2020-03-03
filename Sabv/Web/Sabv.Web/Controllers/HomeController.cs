namespace Sabv.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using Sabv.Common;
    using Sabv.Services.Data;
    using Sabv.Web.ViewModels;
    using Sabv.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly ICategoryService categoryService;
        private readonly IMakesService makesService;
        private readonly ICitiesService citiesService;
        private readonly IModelsService modelsService;
        private readonly IPostsService postsService;

        public HomeController(
            ICategoryService categoryService,
            IMakesService makesService,
            ICitiesService citiesService,
            IModelsService modelsService,
            IPostsService postsService)
        {
            this.categoryService = categoryService;
            this.makesService = makesService;
            this.citiesService = citiesService;
            this.modelsService = modelsService;
            this.postsService = postsService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var categories = this.categoryService.GetAll();
            var makes = this.makesService.GetAll();
            var cities = this.citiesService.GetAll();
            var models = this.modelsService.GetAll();
            var latestPosts = this.postsService.GetLatestPosts();

            var settings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            string json = JsonConvert.SerializeObject(models.ToArray(), settings);
            string content = System.IO.File.ReadAllText(GlobalConstants.MakesAndModelsJsonPath);
            if (!content.Contains(json))
            {
                System.IO.File.WriteAllText(GlobalConstants.MakesAndModelsJsonPath, json);
            }

            var model = new HomePageViewModel()
            {
                Categories = categories,
                Makes = makes,
                Cities = cities,
                LatestPosts = latestPosts,
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
