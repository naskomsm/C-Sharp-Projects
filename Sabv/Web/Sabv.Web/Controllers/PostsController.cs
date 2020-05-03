namespace Sabv.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading;
    using System.Threading.Tasks;

    using cloudscribe.Pagination.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using Sabv.Data.Models;
    using Sabv.Data.Models.Enums;
    using Sabv.Services.Data;
    using Sabv.Services.Mapping;
    using Sabv.Web.Infrastructure.Informants;
    using Sabv.Web.Infrastructure.Informants.Contracts;
    using Sabv.Web.ViewModels.Comments;
    using Sabv.Web.ViewModels.Models;
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
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICloudinaryService cloudinaryService;
        private readonly ICommentsService commentsService;

        public PostsController(
            IPostsService postsService,
            ICitiesService citiesService,
            ICategoriesService categoriesService,
            IMakesService makesService,
            IModelsService modelsService,
            IVehicleCategoriesService vehicleCategoriesService,
            IColorService colorService,
            UserManager<ApplicationUser> userManager,
            ICloudinaryService cloudinaryService,
            ICommentsService commentsService)
        {
            this.postsService = postsService;
            this.citiesService = citiesService;
            this.categoriesService = categoriesService;
            this.makesService = makesService;
            this.modelsService = modelsService;
            this.vehicleCategoriesService = vehicleCategoriesService;
            this.colorService = colorService;
            this.userManager = userManager;
            this.cloudinaryService = cloudinaryService;
            this.commentsService = commentsService;
        }

        [HttpGet]
        [Route("/Api/AllModels")]
        public ActionResult<ICollection<ModelsReturnModel>> AllModels()
        {
            var models = this.modelsService.GetAll<ModelsReturnModel>().ToList();
            return models;
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var postDetails = this.postsService.GetDetails<PostDetailsViewModel>(id);
            var userChecker = this.User ?? (ClaimsPrincipal)Thread.CurrentPrincipal;
            var user = await this.userManager.GetUserAsync(userChecker);

            var commentViewModel = new CommentViewModel()
            {
                Comments = this.commentsService.GetAll().Where(x => x.PostId == id).OrderByDescending(x => x.UserLikes.Count),
                PostId = id,
                User = user,
            };

            var model = new PostDetailsAndCommentsViewModel()
            {
                PostDetails = postDetails,
                CommentViewModel = commentViewModel,
            };

            return this.View(model);
        }

        [HttpGet]
        public IActionResult Search()
        {
            var engineTypes = Informant.GetItems(new EngineInformant());
            var eurostandards = Informant.GetItems(new EurostandardInformant());
            var transmissionTypes = Informant.GetItems(new TransmissionTypeInformant());
            var currencies = Informant.GetItems(new CurrencyInformant());
            var yearsFrom = Informant.GetItems(new YearFromInformant());
            var yearsTo = Informant.GetItems(new YearToInformant());

            var categories = new List<SelectListItem>() { new SelectListItem() { Text = "All", Selected = true } };
            categories.AddRange(this.categoriesService.GetAllAsNoTracking<Category>()
               .Select(x => new SelectListItem() { Text = x.Name })
               .ToList<SelectListItem>());

            var cities = new List<SelectListItem>() { new SelectListItem() { Text = "All", Selected = true } };
            cities.AddRange(this.citiesService.GetAllAsNoTracking<City>()
                .Select(x => new SelectListItem() { Text = x.Name })
                .ToList<SelectListItem>());

            var colors = new List<SelectListItem>() { new SelectListItem() { Text = "All", Selected = true } };
            colors.AddRange(this.colorService.GetAllAsNoTracking<Color>()
                .Select(x => new SelectListItem() { Text = x.Name })
                .ToList<SelectListItem>());

            var makes = new List<SelectListItem>() { new SelectListItem() { Text = "All", Selected = true } };
            makes.AddRange(this.makesService.GetAllAsNoTracking<Make>()
                .Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() })
                .ToList<SelectListItem>());

            var vehicleCategories= new List<SelectListItem>() { new SelectListItem() { Text = "All", Selected = true } };
            vehicleCategories.AddRange(this.vehicleCategoriesService.GetAllAsNoTracking<VehicleCategory>()
                .Select(x => new SelectListItem() { Text = x.Name })
                .ToList<SelectListItem>());

            var model = new SearchViewModel()
            {
                Categories = categories,
                Cities = cities,
                Colors = colors,
                Makes = makes,
                VehicleCategories = vehicleCategories,
                EngineTypes = engineTypes,
                Eurostandards = eurostandards,
                TransmissionTypes = transmissionTypes,
                Currencies = currencies,
                YearsFrom = yearsFrom,
                YearsTo = yearsTo,
            };

            return this.View(model);
        }

        [HttpGet]
        public IActionResult All(PostDetailsInputModel inputModel, int pageNumber = 1, int pageSize = 5)
        {
            var excludeRecords = (pageSize * pageNumber) - pageSize;

            var posts = this.postsService
                .Filter(inputModel)
                .AsQueryable()
                .Skip(excludeRecords)
                .Take(pageSize)
                .To<AllPagePostViewModel>();

            var model = new PagedResult<AllPagePostViewModel>()
            {
                Data = posts.AsNoTracking().ToList(),
                TotalItems = this.postsService.Filter(inputModel).Count(),
                PageNumber = pageNumber,
                PageSize = pageSize,
            };

            return this.View("All", model);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            var engineTypes = Informant.GetItems(new EngineInformant());
            var eurostandards = Informant.GetItems(new EurostandardInformant());
            var transmissionTypes = Informant.GetItems(new TransmissionTypeInformant());
            var currencies = Informant.GetItems(new CurrencyInformant());
            var years = Informant.GetItems(new YearToInformant());

            var categories = this.categoriesService.GetAllAsNoTracking<Category>()
                .Select(x => new SelectListItem() { Text = x.Name, Selected = x.Name == "Cars and jeeps" })
                .ToList<SelectListItem>();

            var cities = this.citiesService.GetAllAsNoTracking<City>()
                .Select(x => new SelectListItem() { Text = x.Name })
                .ToList<SelectListItem>();

            var colors = this.colorService.GetAllAsNoTracking<Color>()
                .Select(x => new SelectListItem() { Text = x.Name })
                .ToList<SelectListItem>();

            var makes = this.makesService.GetAllAsNoTracking<Make>()
                .Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() })
                .ToList<SelectListItem>();

            var vehicleCategories = this.vehicleCategoriesService.GetAllAsNoTracking<VehicleCategory>()
                .Select(x => new SelectListItem() { Text = x.Name })
                .ToList<SelectListItem>();

            var viewModel = new CreatePageViewModel()
            {
                Categories = categories,
                Cities = cities,
                Colors = colors,
                Makes = makes,
                VehicleCategories = vehicleCategories,
                EngineTypes = engineTypes,
                Eurostandards = eurostandards,
                TransmissionTypes = transmissionTypes,
                Currencies = currencies,
                Years = years,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreatePageInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Create();
            }

            var category = this.categoriesService.GetCategoryByName(inputModel.PostCategory);
            var city = this.citiesService.GetCityByName(inputModel.Town);
            var color = this.colorService.GetColorByName(inputModel.Color);
            var make = this.makesService.GetMakeById(inputModel.Make.Value);
            var model = this.modelsService.GetModelByName(inputModel.Model);
            var vehicleCategory = this.vehicleCategoriesService.GetVehicleCategoryByName(inputModel.VehicleCategory);

            var userChecker = this.User ?? (ClaimsPrincipal)Thread.CurrentPrincipal;
            var user = await this.userManager.GetUserAsync(userChecker);

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
                Horsepower = inputModel.Horsepower.Value,
                Email = inputModel.Email,
                Eurostandard = eurostandard,
                TransmissionType = transmissionType,
                ManufactureDate = new DateTime(inputModel.Year.Value, 1, 1),
                Mileage = inputModel.Mileage.Value,
                Name = make.Name + " " + model.Name + " " + inputModel.Modification,
                Price = inputModel.Price.Value,
                VehicleCategory = vehicleCategory,
                VehicleCategoryId = vehicleCategory.Id,
                PhoneNumber = inputModel.PhoneNumber,
                User = user,
                UserId = user.Id,
            };

            await this.postsService.AddAsync(post);
            var images = await this.cloudinaryService.UploadAsync(inputModel.Files);

            foreach (var image in images)
            {
                var postImage = new PostImage()
                {
                    Image = image,
                    ImageId = image.Id,
                    Post = post,
                    PostId = post.Id,
                };

                await this.postsService.AddImageToPost(post.Id, postImage);
            }

            return this.RedirectToAction("Details", "Posts", new { id = post.Id });
        }
    }
}
