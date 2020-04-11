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
            var engineTypes = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "All", Selected = true },
                new SelectListItem() { Text = "Petrol", Value = "Petrol" },
                new SelectListItem() { Text = "Disel", Value = "Disel" },
                new SelectListItem() { Text = "Electric", Value = "Electric" },
                new SelectListItem() { Text = "Hybrid", Value = "Hybrid" },
            };

            var eurostandards = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "All", Selected = true },
                new SelectListItem() { Text = "Euro 1", Value = "1" },
                new SelectListItem() { Text = "Euro 2", Value = "2" },
                new SelectListItem() { Text = "Euro 3", Value = "3" },
                new SelectListItem() { Text = "Euro 4", Value = "4" },
                new SelectListItem() { Text = "Euro 5", Value = "5" },
                new SelectListItem() { Text = "Euro 6", Value = "6" },
            };

            var transmissionTypes = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "All", Selected = true },
                new SelectListItem() { Text = "Manual", Value = "Manual" },
                new SelectListItem() { Text = "Automatic", Value = "Automatic" },
            };

            var currencies = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "All", Selected = true },
                new SelectListItem() { Text = "LV", Value = "LV" },
                new SelectListItem() { Text = "USD", Value = "USD" },
                new SelectListItem() { Text = "EUR", Value = "EUR" },
            };

            var yearsFrom = new List<SelectListItem>();
            yearsFrom.Add(new SelectListItem() { Text = "All", Selected = true });
            for (int i = 2021; i >= 1960; i--)
            {
                yearsFrom.Add(new SelectListItem() { Text = i.ToString() });
            }

            var yearsTo = new List<SelectListItem>();
            yearsTo.Add(new SelectListItem() { Text = "All", Selected = true });
            for (int i = 2021; i >= 1960; i--)
            {
                yearsTo.Add(new SelectListItem() { Text = i.ToString() });
            }

            var categories = new List<Category>();
            categories.Add(new Category() { Name = "All" });
            categories.AddRange(this.categoriesService.GetAll().AsQueryable().AsNoTracking().ToList());

            var cities = new List<City>();
            cities.Add(new City() { Name = "All" });
            cities.AddRange(this.citiesService.GetAll().AsQueryable().AsNoTracking().ToList());

            var colors = new List<Color>();
            colors.Add(new Color() { Name = "All" });
            colors.AddRange(this.colorService.GetAll().AsQueryable().AsNoTracking().ToList());

            var makes = new List<Make>();
            makes.Add(new Make() { Name = "All" });
            makes.AddRange(this.makesService.GetAll().AsQueryable().AsNoTracking().ToList());

            var vehicleCategories = new List<VehicleCategory>();
            vehicleCategories.Add(new VehicleCategory() { Name = "All" });
            vehicleCategories.AddRange(this.vehicleCategoriesService.GetAll().AsQueryable().AsNoTracking().ToList());

            var model = new SearchViewModel()
            {
                Categories = categories.Select(x => new SelectListItem() { Text = x.Name, Selected = x.Name == "All" }).ToList<SelectListItem>(),
                Cities = cities.Select(x => new SelectListItem() { Text = x.Name, Selected = x.Name == "All" }).ToList<SelectListItem>(),
                Colors = colors.Select(x => new SelectListItem() { Text = x.Name, Selected = x.Name == "All" }).ToList<SelectListItem>(),
                Makes = makes.Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString(), Selected = x.Name == "All" }).ToList<SelectListItem>(),
                VehicleCategories = vehicleCategories.Select(x => new SelectListItem() { Text = x.Name, Selected = x.Name == "All" }).ToList<SelectListItem>(),
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
            var engineTypes = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Petrol", Value = "Petrol" },
                new SelectListItem() { Text = "Disel", Value = "Disel" },
                new SelectListItem() { Text = "Electric", Value = "Electric" },
                new SelectListItem() { Text = "Hybrid", Value = "Hybrid" },
            };

            var eurostandards = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Euro 1", Value = "1" },
                new SelectListItem() { Text = "Euro 2", Value = "2" },
                new SelectListItem() { Text = "Euro 3", Value = "3" },
                new SelectListItem() { Text = "Euro 4", Value = "4" },
                new SelectListItem() { Text = "Euro 5", Value = "5" },
                new SelectListItem() { Text = "Euro 6", Value = "6" },
            };

            var transmissionTypes = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Manual", Value = "Manual" },
                new SelectListItem() { Text = "Automatic", Value = "Automatic" },
            };

            var currencies = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "LV", Value = "LV" },
                new SelectListItem() { Text = "USD", Value = "USD" },
                new SelectListItem() { Text = "EUR", Value = "EUR" },
            };

            var years = new List<SelectListItem>();
            for (int i = 2021; i >= 1960; i--)
            {
                years.Add(new SelectListItem() { Text = i.ToString() });
            }

            var viewModel = new CreatePageViewModel()
            {
                Categories = this.categoriesService.GetAll().AsQueryable().AsNoTracking().Select(x => new SelectListItem() { Text = x.Name, Selected = x.Name == "Cars and jeeps" }).ToList<SelectListItem>(),
                Cities = this.citiesService.GetAll().AsQueryable().AsNoTracking().Select(x => new SelectListItem() { Text = x.Name }).ToList<SelectListItem>(),
                Colors = this.colorService.GetAll().AsQueryable().AsNoTracking().Select(x => new SelectListItem() { Text = x.Name }).ToList<SelectListItem>(),
                Makes = this.makesService.GetAll().AsQueryable().AsNoTracking().Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList<SelectListItem>(),
                VehicleCategories = this.vehicleCategoriesService.GetAll().AsQueryable().Select(x => new SelectListItem() { Text = x.Name }).ToList<SelectListItem>(),
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
