namespace Sabv.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Sabv.Common;
    using Sabv.Data.Models;
    using Sabv.Services.Data.Contracts;
    using Sabv.Services.Models.AdditionalInfos;
    using Sabv.Services.Models.MainInfos;
    using Sabv.Services.Models.Posts;
    using Sabv.Web.ViewModels.Posts;

    public class PostsController : BaseController
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IDataSetsService dataSetsService;
        private readonly IPostCategoriesService postCategoriesService;
        private readonly IVehicleTypeCategoriesService vehicleTypeCategoriesService;
        private readonly IImagesService imagesService;
        private readonly IPostsService postsService;
        private readonly IMainInfoService mainInfoService;
        private readonly IAdditionalInfoService additionalInfoService;

        public PostsController(
            IHttpContextAccessor httpContextAccessor,
            IDataSetsService dataSetsService,
            IPostCategoriesService postCategoriesService,
            IVehicleTypeCategoriesService carTypeCategoriesService,
            IImagesService imagesService,
            IPostsService postsService,
            IMainInfoService mainInfoService,
            IAdditionalInfoService additionalInfoService)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.dataSetsService = dataSetsService;
            this.postCategoriesService = postCategoriesService;
            this.vehicleTypeCategoriesService = carTypeCategoriesService;
            this.imagesService = imagesService;
            this.postsService = postsService;
            this.mainInfoService = mainInfoService;
            this.additionalInfoService = additionalInfoService;
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
                Months = allDataSets.Months,
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
        public async Task<IActionResult> CheckText(CheckTextInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("Create");
            }

            var model = new CheckTextViewModel()
            {
                Email = inputModel.Email,
                Make = inputModel.Make,
                Model = inputModel.Model,
                Currency = inputModel.Currency,
                Price = inputModel.Price,
                CarCategory = inputModel.CarCategory,
                Town = inputModel.Town,
                MainInfo = new MainInfo()
                {
                    Color = inputModel.Color,
                    EuroStandard = inputModel.EuroStandard,
                    TransmissionType = inputModel.TransmissionType,
                    EngineType = inputModel.EngineType,
                    HorsePower = inputModel.HorsePower,
                    Mileage = inputModel.Mileage,
                    VehicleCreatedOn = new DateTime(inputModel.Year, inputModel.Month, 1),
                },
                PhoneNumber = inputModel.MobileNumber,
                PostCategory = inputModel.PostCategory,
            };

            var mainInfoAddModel = new AddMainInfoModel()
            {
                Color = inputModel.Color,
                EuroStandard = (int)inputModel.EuroStandard,
                TransmissionType = (int)inputModel.TransmissionType,
                EngineType = (int)inputModel.EngineType,
                Horsepower = inputModel.HorsePower,
                Mileage = (int)inputModel.Mileage,
                VehicleCreatedOn = new DateTime(inputModel.Year, inputModel.Month, 1),
            };

            var additionalInfoAddModel = new AddAdditionalInfoModel()
            {
                ABS = inputModel.ABS,
                Airbags = inputModel.Airbags,
                GPS = inputModel.GPS,
                Parktronic = inputModel.Parktronic,
                TractionControl = inputModel.TractionControl,
                AllWheelDrive = inputModel.AllWheelDrive,
                Barter = inputModel.Barter,
                Tuned = inputModel.Tuned,
                FiveDoors = inputModel.FiveDoors,
                ThreeDoors = inputModel.ThreeDoors,
                AirSuspension = inputModel.AirSuspension,
                ClimateControl = inputModel.ClimateControl,
                ElectricMirrors = inputModel.ElectricMirrors,
                ElectricWindows = inputModel.ElectricWindows,
                USBAudio = inputModel.USBAudio,
                RainSensor = inputModel.RainSensor,
                StartStopFunction = inputModel.StartStopFunction,
                Town = inputModel.Town,
            };

            var postCategoryId = this.postCategoriesService.GetAllCategories().FirstOrDefault(x => x.Name == inputModel.PostCategory).Id;
            var mainInfoId = await this.mainInfoService.AddAsync(mainInfoAddModel);
            var additionalInfoId = await this.additionalInfoService.AddAsync(additionalInfoAddModel);
            var vehicleCategoryId = this.vehicleTypeCategoriesService.GetAllCategories().FirstOrDefault(x => x.Name == inputModel.CarCategory).Id;
            var userId = this.httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var postAddModel = new AddPostModel()
            {
                Name = inputModel.Make + " " + inputModel.Model + " " + inputModel.Modification,
                Description = inputModel.Description != null ? inputModel.Description : "Няма описание",
                PhoneNumber = inputModel.MobileNumber,
                Price = inputModel.Price,
                Condition = (int)inputModel.Condition,
                Model = inputModel.Model,
                Make = inputModel.Make,
                Currency = (int)inputModel.Currency,
                PostCategoryId = postCategoryId,
                MainInfoId = mainInfoId,
                AdditionalInfoId = additionalInfoId,
                VehicleCategoryId = vehicleCategoryId,
                UserId = userId,
            };

            await this.postsService.AddPostAsync(postAddModel);

            return this.View(model);
        }

        [HttpGet]
        [Authorize]
        public IActionResult AddPictures()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult All(AllInputSearchViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("Search");
            }

            var posts = this.postsService.Filter(inputModel);

            var viewModel = new AllPostsViewModel()
            {
                Posts = posts.Select(x => new PostViewModel()
                {
                    Id = x.Id,
                    CreatedOn = x.CreatedOn.ToString(),
                    ImageUrl = GlobalConstants.CloudinaryLinkWithoutSuffix + x.Images.FirstOrDefault().Url,
                    MainInfo = x.MainInfo,
                    Mileage = x.MainInfo.Mileage,
                    Name = x.Name,
                    Price = x.Price,
                })
                .ToList(),
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return this.Redirect("/");
            }

            var model = await this.postsService.GetDetailsAsync(id);
            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPictures(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            var filePaths = new List<string>();
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var filePath = Path.GetTempFileName();
                    filePaths.Add(filePath);

                    using var stream = new FileStream(filePath, FileMode.Create);
                    await formFile.CopyToAsync(stream);
                }
            }

            var urls = new List<string>();
            foreach (var path in filePaths)
            {
                var url = await this.imagesService.UploadFileAsync(path);
                url = url.Substring(GlobalConstants.CloudinaryLinkLengthWithoutSuffix);
                urls.Add(url);
            }

            foreach (var url in urls)
            {
                await this.imagesService.AddToBaseAsync(url, null);
            }

            return this.View();
        }
    }
}
