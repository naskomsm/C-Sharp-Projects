namespace Sabv.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using Sabv.Common;
    using Sabv.Services.Data;
    using Sabv.Web.ViewModels.Posts;

    public class PostsController : BaseController
    {
        private readonly IPostsService postsService;
        private readonly ICloudinaryService cloudinaryService;
        private readonly IExtrasService extrasService;
        private readonly IVehicleCategoryService vehicleCategoryService;
        private readonly ICategoryService categoryService;
        private readonly IMakesService makesService;
        private readonly ICitiesService citiesService;
        private readonly IModelsService modelsService;

        public PostsController(
            ICategoryService categoryService,
            IMakesService makesService,
            ICitiesService citiesService,
            IModelsService modelsService,
            IPostsService postsService,
            ICloudinaryService cloudinaryService,
            IExtrasService extrasService,
            IVehicleCategoryService vehicleCategoryService)
        {
            this.postsService = postsService;
            this.categoryService = categoryService;
            this.makesService = makesService;
            this.citiesService = citiesService;
            this.modelsService = modelsService;
            this.cloudinaryService = cloudinaryService;
            this.extrasService = extrasService;
            this.vehicleCategoryService = vehicleCategoryService;
        }

        [HttpGet]
        public IActionResult All()
        {
            var posts = this.postsService.GetAll();

            var model = new AllPostsViewModel()
            {
                Posts = posts,
            };

            return this.View(model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = this.postsService.GetDetails(id);

            return this.View(model);
        }

        [HttpGet]
        public IActionResult Images()
        {
            return this.View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = this.categoryService.GetAll();
            var makes = this.makesService.GetAll();
            var cities = this.citiesService.GetAll();
            var models = this.modelsService.GetAll();

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

            var jsonStringColors = await System.IO.File.ReadAllTextAsync(GlobalConstants.ColorsJsonPath);
            var jsonStringMonths = await System.IO.File.ReadAllTextAsync(GlobalConstants.MonthsJsonPath);

            var parsedDataColors = JsonConvert.DeserializeObject<string[]>(jsonStringColors);
            var parsedDataMonths = JsonConvert.DeserializeObject<string[]>(jsonStringMonths);

            var model = new CreatePageViewModel()
            {
                Categories = categories,
                Cities = cities,
                Makes = makes,
                Colors = parsedDataColors,
                Comfort = this.extrasService.GetAllComforts().FirstOrDefault(),
                Exterior = this.extrasService.GetAllExteriors().FirstOrDefault(),
                Other = this.extrasService.GetAllOthers().FirstOrDefault(),
                Safety = this.extrasService.GetAllSafeties().FirstOrDefault(),
                Months = parsedDataMonths,
                VehicleCategories = this.vehicleCategoryService.GetAll(),
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Images(List<IFormFile> files)
        {
            await this.cloudinaryService.UploadAsync(files);

            return this.View();
        }
    }
}
