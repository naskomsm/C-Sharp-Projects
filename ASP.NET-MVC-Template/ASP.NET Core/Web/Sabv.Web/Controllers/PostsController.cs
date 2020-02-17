namespace Sabv.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Sabv.Services.Data;
    using Sabv.Web.ViewModels.Posts;

    public class PostsController : BaseController
    {
        private readonly IDataSetsService dataSetsService;

        public PostsController(IDataSetsService dataSetsService)
        {
            this.dataSetsService = dataSetsService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var allDataSets = await this.dataSetsService.GetAllDataSets();

            var model = new SearchPageViewModel()
            {
                Categories = allDataSets.Categories,
                Cities = allDataSets.Cities,
                Makes = allDataSets.Makes,
                Years = allDataSets.Years,
                Colors = allDataSets.Colors,
                Features = allDataSets.Features,
                CarTypeCategories = allDataSets.CarTypeCategories,
            };

            return this.View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Search()
        {
            var allDataSets = await this.dataSetsService.GetAllDataSets();

            var model = new SearchPageViewModel()
            {
                Categories = allDataSets.Categories,
                Cities = allDataSets.Cities,
                Makes = allDataSets.Makes,
                Years = allDataSets.Years,
                Colors = allDataSets.Colors,
                Features = allDataSets.Features,
                CarTypeCategories = allDataSets.CarTypeCategories,
            };

            return this.View(model);
        }

        [HttpGet]
        public IActionResult CheckText()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult AddPictures()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult AddPictures(string arg)
        {
            return this.View();
        }
    }
}
