namespace Sabv.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Sabv.Common;
    using Sabv.Data.Models;
    using Sabv.Services.Data.Contracts;
    using Sabv.Web.ViewModels.Posts;

    public class PostsController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDataSetsService dataSetsService;
        private readonly IPostCategoriesService postCategoriesService;
        private readonly IVehicleTypeCategoriesService vehicleTypeCategoriesService;
        private readonly IImagesService imagesService;
        private readonly IPostsService postsService;

        public PostsController(
            UserManager<ApplicationUser> userManager,
            IDataSetsService dataSetsService,
            IPostCategoriesService postCategoriesService,
            IVehicleTypeCategoriesService carTypeCategoriesService,
            IImagesService imagesService,
            IPostsService postsService)
        {
            this.dataSetsService = dataSetsService;
            this.postCategoriesService = postCategoriesService;
            this.vehicleTypeCategoriesService = carTypeCategoriesService;
            this.imagesService = imagesService;
            this.postsService = postsService;
            this.userManager = userManager;
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

            return this.View();
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
            var posts = this.postsService
                    .GetAllPosts()
                    .ToList();

            if (inputModel.PostCategory != null && inputModel.PostCategory != "Всички")
            {
                posts = this.postsService
                    .GetAllPosts()
                    .Where(x => x.PostCategory.Name.ToString().ToLower() == inputModel.PostCategory.ToLower())
                    .ToList();
            }

            if (inputModel.Make != null && inputModel.Make != "Всички")
            {
                posts = posts
                    .Where(x => x.Make.ToLower() == inputModel.Make.ToLower())
                    .ToList();
            }

            if (inputModel.Model != null && inputModel.Model != "Всички")
            {
                posts = posts
                    .Where(x => x.Model.ToLower() == inputModel.Model.ToLower())
                    .ToList();
            }

            if (inputModel.MaxMileage != null)
            {
                var isNumber = double.TryParse(inputModel.MaxMileage, out _);

                if (isNumber)
                {
                    posts = posts
                        .Where(x => x.MainInfo.Mileage <= double.Parse(inputModel.MaxMileage))
                        .ToList();
                }
            }

            if (inputModel.EngineType != null && inputModel.EngineType != "Всички")
            {
                posts = posts
                    .Where(x => x.MainInfo.EngineType.ToString().ToLower() == inputModel.EngineType.ToLower())
                    .ToList();
            }

            if (inputModel.HorsePowerFrom != null)
            {
                var isNumber = double.TryParse(inputModel.HorsePowerFrom, out _);

                if (isNumber)
                {
                    posts = posts
                        .Where(x => x.MainInfo.HorsePower >= double.Parse(inputModel.HorsePowerFrom))
                        .ToList();
                }
            }

            if (inputModel.HorsePowerTo != null)
            {
                var isNumber = double.TryParse(inputModel.HorsePowerTo, out _);

                if (isNumber)
                {
                    posts = posts
                        .Where(x => x.MainInfo.HorsePower <= double.Parse(inputModel.HorsePowerTo))
                        .ToList();
                }
            }

            if (inputModel.EuroStandard != null && inputModel.EuroStandard != "Всички")
            {
                posts = posts
                    .Where(x => (int)x.MainInfo.EuroStandard == int.Parse(inputModel.EuroStandard))
                    .ToList();
            }

            if (inputModel.TransmissionType != null && inputModel.TransmissionType != "Всички")
            {
                posts = posts
                    .Where(x => x.MainInfo.TransmissionType.ToString().ToLower() == inputModel.TransmissionType.ToLower())
                    .ToList();
            }

            if (inputModel.CarCategory != null && inputModel.CarCategory != "Всички")
            {
                posts = posts
                    .Where(x => x.VehicleCategory.Name.ToLower() == inputModel.CarCategory.ToLower())
                    .ToList();
            }

            if (inputModel.PriceFrom != null)
            {
                var isNumber = decimal.TryParse(inputModel.PriceFrom, out _);

                if (isNumber)
                {
                    posts = posts
                        .Where(x => x.Price >= decimal.Parse(inputModel.PriceFrom))
                        .ToList();
                }
            }

            if (inputModel.PriceTo != null)
            {
                var isNumber = decimal.TryParse(inputModel.HorsePowerTo, out _);

                if (isNumber)
                {
                    posts = posts
                        .Where(x => x.Price <= decimal.Parse(inputModel.PriceTo))
                        .ToList();
                }
            }

            if (inputModel.Currency != null && inputModel.Currency != "Всички")
            {
                posts = posts
                    .Where(x => x.Currency.ToString().ToLower() == inputModel.Currency.ToLower())
                    .ToList();
            }

            if (inputModel.YearFrom != null)
            {
                var modifiedYearFrom = inputModel.YearFrom.Replace("от ", string.Empty);
                if (modifiedYearFrom != "Всички")
                {
                    posts = posts
                        .Where(x => x.MainInfo.VehicleCreatedOn >= DateTime.Parse(modifiedYearFrom))
                        .ToList();
                }
            }

            if (inputModel.YearTo != null)
            {
                var modifiedYearTo = inputModel.YearTo.Replace("до ", string.Empty);
                if (modifiedYearTo != "Всички")
                {
                    posts = posts
                        .Where(x => x.MainInfo.VehicleCreatedOn <= DateTime.Parse(modifiedYearTo))
                        .ToList();
                }
            }

            if (inputModel.Color != null && inputModel.Color != "Всички")
            {
                posts = posts
                    .Where(x => x.MainInfo.Color.ToLower() == inputModel.Color.ToLower())
                    .ToList();
            }

            if (inputModel.Town != null && inputModel.Town != "Всички")
            {
                posts = posts
                    .Where(x => x.AdditionalInfo.Town.ToLower() == inputModel.Town.ToLower())
                    .ToList();
            }

            var inputCheckBoxes = inputModel.GetAllTrueProperties.ToList();
            foreach (var checkedBox in inputCheckBoxes)
            {
                posts = posts
                    .Where(x => x.AdditionalInfo.SafetyInfo.GetAllTrueProperties.Contains(checkedBox))
                    .ToList();

                posts = posts
                    .Where(x => x.AdditionalInfo.ComfortInfo.GetAllTrueProperties.Contains(checkedBox))
                    .ToList();

                posts = posts
                    .Where(x => x.AdditionalInfo.ExteriorInfo.GetAllTrueProperties.Contains(checkedBox))
                    .ToList();

                posts = posts
                    .Where(x => x.AdditionalInfo.OtherInfo.GetAllTrueProperties.Contains(checkedBox))
                    .ToList();
            }

            var viewModel = new AllPostsViewModel()
            {
                Posts = posts
                .Select(x => new PostViewModel()
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
