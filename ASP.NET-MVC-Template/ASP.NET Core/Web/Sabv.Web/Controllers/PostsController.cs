namespace Sabv.Web.Controllers
{
    using System.IO;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Sabv.Services.Data.Contracts;
    using Sabv.Web.ViewModels.Posts;

    public class PostsController : BaseController
    {
        private readonly IDataSetsService dataSetsService;
        private readonly IPostCategoriesService postCategoriesService;
        private readonly IVehicleTypeCategoriesService vehicleTypeCategoriesService;

        public PostsController(
            IDataSetsService dataSetsService,
            IPostCategoriesService postCategoriesService,
            IVehicleTypeCategoriesService carTypeCategoriesService)
        {
            this.dataSetsService = dataSetsService;
            this.postCategoriesService = postCategoriesService;
            this.vehicleTypeCategoriesService = carTypeCategoriesService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create()
        {
            var allDataSets = await this.dataSetsService.GetDataForSearchAndCreatePageAsync();
            var categories = this.postCategoriesService.GetAllCategoriesNames();
            var carTypeCategories = this.vehicleTypeCategoriesService.GetAllCategoriesNames();

            var model = new SearchPageViewModel()
            {
                Categories = categories,
                Cities = allDataSets.Cities,
                Years = allDataSets.Years,
                Colors = allDataSets.Colors,
                Features = allDataSets.Features,
                CarTypeCategories = carTypeCategories,
            };

            return this.View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Search()
        {
            var allDataSets = await this.dataSetsService.GetDataForSearchAndCreatePageAsync();
            var categories = this.postCategoriesService.GetAllCategoriesNames();
            var carTypeCategories = this.vehicleTypeCategoriesService.GetAllCategoriesNames();

            var model = new SearchPageViewModel()
            {
                Categories = categories,
                Cities = allDataSets.Cities,
                Years = allDataSets.Years,
                Colors = allDataSets.Colors,
                Features = allDataSets.Features,
                CarTypeCategories = carTypeCategories,
            };

            return this.View(model);
        }

        [HttpGet]
        [Authorize]
        public IActionResult CheckText()
        {
            // A lot of validations for empty fields
            System.Console.WriteLine();

            return this.View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult AddPictures()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddPictures(string[] myFile)
        {
            var picture1 = new FileInfo(myFile[0]);
            var picture2 = new FileInfo(myFile[1]);
            



            return this.View();
        }
    }
}
