namespace Sabv.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Sabv.Services.Data.Contracts;
    using Sabv.Web.ViewModels;
    using Sabv.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IDataSetsService dataSetsService;
        private readonly IPostCategoriesService postCategoriesService;

        public HomeController(IDataSetsService dataSetsService, IPostCategoriesService postCategoriesService)
        {
            this.dataSetsService = dataSetsService;
            this.postCategoriesService = postCategoriesService;
        }

        public async Task<IActionResult> Index()
        {
            var allDataSets = await this.dataSetsService.GetAllDataSetsAsync();
            var categories = this.postCategoriesService
                .GetAllCategories()
                .Select(x => x.Name)
                .ToArray();

            var model = new HomePageViewModel()
            {
                Categories = categories,
                Cities = allDataSets.Cities,
                Years = allDataSets.Years,
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
