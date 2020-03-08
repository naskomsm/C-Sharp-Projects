namespace Sabv.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Sabv.Data;
    using Sabv.Data.Models;
    using Sabv.Data.Models.Enums;
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
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICloudinaryService cloudinaryService;
        private readonly ApplicationDbContext dbContext;

        public PostsController(
            IPostsService postsService,
            ICitiesService citiesService,
            ICategoriesService categoriesService,
            IMakesService makesService,
            IModelsService modelsService,
            IVehicleCategoriesService vehicleCategoriesService,
            IColorService colorService,
            IJsonService jsonService,
            UserManager<ApplicationUser> userManager,
            ICloudinaryService cloudinaryService,
            ApplicationDbContext dbContext)
        {
            this.postsService = postsService;
            this.citiesService = citiesService;
            this.categoriesService = categoriesService;
            this.makesService = makesService;
            this.modelsService = modelsService;
            this.vehicleCategoriesService = vehicleCategoriesService;
            this.colorService = colorService;
            this.jsonService = jsonService;
            this.userManager = userManager;
            this.cloudinaryService = cloudinaryService;
            this.dbContext = dbContext;
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

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new CreatePageViewModel()
            {
                Categories = this.categoriesService.GetAll().ToList(),
                Cities = this.citiesService.GetAll().ToList(),
                Colors = this.colorService.GetAll().ToList(),
                Makes = this.makesService.GetAll().ToList(),
                VehicleCategories = this.vehicleCategoriesService.GetAll().ToList(),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreatePageInputModel inputModel, ICollection<IFormFile> files)
        {
            var category = this.categoriesService.GetCategoryByName(inputModel.PostCategory);
            var city = this.citiesService.GetCityByName(inputModel.Town);
            var color = this.colorService.GetColorByName(inputModel.Color);
            var make = this.makesService.GetMakeById(inputModel.Make);
            var model = this.modelsService.GetModelByName(inputModel.Model);
            var vehicleCategory = this.vehicleCategoriesService.GetVehicleCategoryByName(inputModel.VehicleCategory);

            var email = this.HttpContext.User.Identities.FirstOrDefault().Name;
            var user = await this.userManager.FindByEmailAsync(email);

            var condition = (Condition)Enum.Parse(typeof(Condition), inputModel.Condition, true);
            var currency = (Currency)Enum.Parse(typeof(Currency), inputModel.Currency, true);
            var engineType = (EngineType)Enum.Parse(typeof(EngineType), inputModel.EngineType, true);
            var transmissionType = (TransmissionType)Enum.Parse(typeof(TransmissionType), inputModel.TransmissionType, true);
            var eurostandard = (Eurostandard)inputModel.Eurostandard;

            var post = new Post()
            {
                Category = category,
                CategoryId = category.Id,
                City = city,
                Make = make,
                MakeId = make.Id,
                Model = model,
                ModelId = model.Id,
                CityId = city.Id,
                Color = color,
                ColorId = color.Id,
                Condition = condition,
                Currency = currency,
                EngineType = engineType,
                Description = inputModel.Description,
                Horsepower = inputModel.Horsepower,
                Email = inputModel.Email,
                Eurostandard = eurostandard,
                TransmissionType = transmissionType,
                ManufactureDate = new DateTime(inputModel.Year, 1, 1),
                Mileage = inputModel.Mileage,
                Name = make.Name + " " + model.Name + " " + inputModel.Modification,
                Price = inputModel.Price,
                VehicleCategory = vehicleCategory,
                VehicleCategoryId = vehicleCategory.Id,
                PhoneNumber = inputModel.PhoneNumber,
                User = user,
                UserId = user.Id,
            };

            await this.postsService.AddAsync(post);

            var images = await this.cloudinaryService.UploadAsync(files);

            foreach (var image in images)
            {
                var postImage = new PostImage()
                {
                    Image = image,
                    ImageId = image.Id,
                    Post = post,
                    PostId = post.Id,
                };

                post.Images.Add(postImage);
            }

            await this.dbContext.SaveChangesAsync();

            return this.RedirectToAction("Details", "Posts", new { id = post.Id });
        }
    }
}
