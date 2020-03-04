namespace Sabv.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using Sabv.Common;
    using Sabv.Data.Models.Cities;
    using Sabv.Data.Models.Extras;
    using Sabv.Data.Models.Posts;
    using Sabv.Data.Models.PostsImages;
    using Sabv.Data.Models.Users;
    using Sabv.Services.Data;
    using Sabv.Web.ViewModels.Posts;

    public class PostsController : BaseController
    {
        private readonly IPostsService postsService;
        private readonly ICloudinaryService cloudinaryService;
        private readonly IExtrasService extrasService;
        private readonly IVehicleCategoryService vehicleCategoryService;
        private readonly IImageService imageService;
        private readonly UserManager<ApplicationUser> userManager;
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
            IVehicleCategoryService vehicleCategoryService,
            UserManager<ApplicationUser> userManager,
            IImageService imageService)
        {
            this.postsService = postsService;
            this.categoryService = categoryService;
            this.makesService = makesService;
            this.citiesService = citiesService;
            this.modelsService = modelsService;
            this.cloudinaryService = cloudinaryService;
            this.extrasService = extrasService;
            this.vehicleCategoryService = vehicleCategoryService;
            this.imageService = imageService;
            this.userManager = userManager;
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
        [Authorize]
        public IActionResult Images()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult CheckText(CheckTextViewModel checkTextViewModel)
        {
            return this.View(checkTextViewModel);
        }

        [HttpGet]
        [Authorize]
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
        [Authorize]
        public async Task<IActionResult> Create(CreatePageInputModel inputModel)
        {
            // TODO
            // FIX CURRENT USER DONT WORK!!!


            var city = this.citiesService.GetAll().FirstOrDefault(x => x.Name == inputModel.City);
            var category = this.categoryService.GetAll().FirstOrDefault(x => x.Name == inputModel.Category);
            var make = this.makesService.GetById(int.Parse(inputModel.Make));
            var model = this.modelsService.GetAll().FirstOrDefault(x => x.Name == inputModel.Model);
            var vehicleCategory = this.vehicleCategoryService.GetAll().FirstOrDefault(x => x.Name == inputModel.VehicleCategory);

            var post = new Post()
            {
                //ApplicationUser = user,
                //ApplicationUserId = user.Id,
                Category = category,
                CategoryId = category.Id,
                City = city,
                CityId = city.Id,
                Color = inputModel.Color,
                Comfort = new Comfort()
                {
                    ACC = inputModel.ACC,
                    Airmatic = inputModel.Airmatic,
                    ASS = inputModel.ASS,
                    Bluetooth = inputModel.Bluetooth,
                    BordComputer = inputModel.BordComputer,
                    DVD = inputModel.DVD,
                    ElectricWindows = inputModel.ElectricWindows,
                    ElectricMirrors = inputModel.ElectricMirrors,
                    Navigation = inputModel.Navigation,
                    Steptronic = inputModel.Steptronic,
                    USB = inputModel.USB,
                    SeatHeat = inputModel.SeatHeat,
                    LightSensor = inputModel.LightSensor,
                    Keyless = inputModel.Keyless,
                    EPS = inputModel.EPS,
                },
                Exterior = new Exterior()
                {
                    FourDoors = inputModel.FourDoors,
                    Rims = inputModel.Rims,
                    LED = inputModel.LED,
                    Metalic = inputModel.Metalic,
                },
                Other = new Other()
                {
                    AllWheelDrive = inputModel.AllWheelDrive,
                    LongBase = inputModel.LongBase,
                    Service = inputModel.Service,
                },
                Safety = new Safety()
                {
                    ABS = inputModel.ABS,
                    HDC = inputModel.HDC,
                    ESP = inputModel.ESP,
                    TPMS = inputModel.TPMS,
                    EBD = inputModel.EBD,
                    DSA = inputModel.DSA,
                    Distronic = inputModel.Distronic,
                    PDC = inputModel.PDC,
                    Isofix = inputModel.Isofix,
                    AFL = inputModel.AFL,
                    Airbags = inputModel.Airbags,
                    ASC = inputModel.ASC,
                    ASR = inputModel.ASR,
                    BAS = inputModel.BAS,
                    DBS = inputModel.DBS,
                },
                Horsepower = inputModel.Horsepower,
                Make = make,
                MakeId = make.Id,
                Model = model,
                ModelId = model.Id,
                EngineType = inputModel.EngineType,
                Eurostandard = inputModel.Eurostandard,
                ManufactureDate = new DateTime(inputModel.Year, inputModel.Month, 1),
                Description = inputModel.Descripton ?? "Няма описание",
                Condition = inputModel.Condition,
                CreatedOn = DateTime.UtcNow,
                Email = inputModel.Email,
                IsDeleted = false,
                PhoneNumber = inputModel.PhoneNumber,
                Price = inputModel.Price,
                TransmissionType = inputModel.TransmissionType,
                VehicleCategory = vehicleCategory,
                VehicleCategoryId = vehicleCategory.Id,
                Mileage = inputModel.Mileage,
                Name = inputModel.Make + " " + inputModel.Model + " " + inputModel.Modification,
            };

            await this.postsService.AddAsync(post);

            var defaultPostImage = new PostImage()
            {
                Image = this.imageService.GetById(GlobalConstants.DefaultImageId),
                ImageId = GlobalConstants.DefaultImageId,
                Post = post,
                PostId = post.Id,
            };

            post.Images.Add(defaultPostImage);

            var checkTextViewModel = new CheckTextViewModel()
            {
                Category = post.Category,
                VehicleCategory = post.VehicleCategory,
                TransmissionType = post.TransmissionType,
                Eurostandard = post.Eurostandard,
                EngineType = post.EngineType,
                Color = post.Color,
                Currency = inputModel.Currency,
                Email = post.Email,
                Make = post.Make,
                ManufactureDate = post.ManufactureDate,
                Mileage = post.Mileage,
                Model = post.Model,
                PhoneNumber = post.PhoneNumber,
                Price = post.Price,
                City = post.City,
            };

            return this.RedirectToAction("CheckText", new { checkTextViewModel });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Images(List<IFormFile> files)
        {
            await this.cloudinaryService.UploadAsync(files);

            return this.View();
        }
    }
}
