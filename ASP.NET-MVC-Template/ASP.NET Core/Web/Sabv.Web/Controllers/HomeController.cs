namespace Sabv.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Sabv.Services.Data;
    using Sabv.Web.ViewModels;
    using Sabv.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IDataSetsService dataSetsService;

        public HomeController(IDataSetsService dataSetsService)
        {
            this.dataSetsService = dataSetsService;
        }

        public async Task<IActionResult> Index()
        {
            var allDataSets = await this.dataSetsService.GetAllDataSets();

            var model = new HomePageViewModel()
            {
                Categories = allDataSets.Categories,
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
