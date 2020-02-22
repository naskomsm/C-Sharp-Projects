namespace Sabv.Web.Controllers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Sabv.Common;
    using Sabv.Services.Data.Contracts;
    using Sabv.Web.ViewModels.Posts;

    public class PostsController : BaseController
    {
        private readonly IDataSetsService dataSetsService;
        private readonly IPostCategoriesService postCategoriesService;
        private readonly IVehicleTypeCategoriesService vehicleTypeCategoriesService;
        private readonly IImagesService imagesService;
        private readonly IPostsService postsService;

        public PostsController(
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

        [HttpGet]
        public IActionResult All()
        {
            var posts = this.postsService.GetAllPosts();

            var model = new AllPostsViewModel()
            {
                Posts = posts,
            };

            return this.View(model);
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            return this.View();
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
                var url = await this.imagesService.UploadFile(path);
                url = url.Substring(GlobalConstants.CloudinaryLinkLengthWithoutSuffix);
                urls.Add(url);
            }

            foreach (var url in urls)
            {
                await this.imagesService.AddToBase(url);
            }

            return this.View();
        }
    }
}
