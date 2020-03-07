namespace Sabv.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Sabv.Services.Data;
    using Sabv.Services.Mapping;
    using Sabv.Web.ViewModels.Posts;

    public class PostsController : BaseController
    {
        private readonly IPostsService postsService;
        private readonly ICitiesService citiesService;
        private readonly ICategoriesService categoriesService;
        private readonly IMakesService makesService;
        private readonly IModelsService modelsService;
        private readonly IVehicleCategoriesService vehicleCategoriesService;
        private readonly IColorService colorService;
        private readonly IJsonService jsonService;

        public PostsController(
            IPostsService postsService,
            ICitiesService citiesService,
            ICategoriesService categoriesService,
            IMakesService makesService,
            IModelsService modelsService,
            IVehicleCategoriesService vehicleCategoriesService,
            IColorService colorService,
            IJsonService jsonService)
        {
            this.postsService = postsService;
            this.citiesService = citiesService;
            this.categoriesService = categoriesService;
            this.makesService = makesService;
            this.modelsService = modelsService;
            this.vehicleCategoriesService = vehicleCategoriesService;
            this.colorService = colorService;
            this.jsonService = jsonService;
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = this.postsService.GetDetails<PostDetailsViewModel>(id);
            return this.View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Search()
        {
            await this.jsonService.WriteInJsonMakesAsync(this.modelsService.GetAll().ToArray());

            var model = new SearchViewModel()
            {
                Categories = this.categoriesService.GetAll().ToList(),
                Cities = this.citiesService.GetAll().ToList(),
                Colors = this.colorService.GetAll().ToList(),
                Makes = this.makesService.GetAll().ToList(),
                VehicleCategories = this.vehicleCategoriesService.GetAll().ToList(),
            };

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Search(PostDetailsInputModel inputModel)
        {
            var filteredPosts = this.postsService.Filter(inputModel).AsQueryable();


            var viewmodel = new AllPageViewModel()
            {
                Posts = filteredPosts.To<AllPagePostViewModel>().ToList(),
            };

            return this.View("All", viewmodel);
        }

        [HttpGet]
        public IActionResult All(AllPageViewModel viewmodel)
        {
            return this.View(viewmodel);
        }
    }
}
