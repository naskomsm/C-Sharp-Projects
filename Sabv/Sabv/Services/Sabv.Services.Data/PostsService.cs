namespace Sabv.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Sabv.Common;
    using Sabv.Data.Common.Repositories;
    using Sabv.Data.Models;
    using Sabv.Data.Models.AdditionalInfoFiles;
    using Sabv.Data.Models.Enums;
    using Sabv.Services.Data.Contracts;
    using Sabv.Services.Models.Posts;
    using Sabv.Web.ViewModels.Posts;

    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<Post> postRepository;
        private readonly IDeletableEntityRepository<MainInfo> mainInfoRepository;
        private readonly IDeletableEntityRepository<AdditionalInfo> additionalInfoRepository;
        private readonly IDeletableEntityRepository<VehicleCategory> vehicleCategoryRepository;
        private readonly IDeletableEntityRepository<PostCategory> postCategoryRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public PostsService(
            IDeletableEntityRepository<Post> postRepository,
            IDeletableEntityRepository<MainInfo> mainInfoRepository,
            IDeletableEntityRepository<AdditionalInfo> additionalInfoRepository,
            IDeletableEntityRepository<VehicleCategory> vehicleCategoryRepository,
            IDeletableEntityRepository<PostCategory> postCategoryRepository,
            UserManager<ApplicationUser> userManager)
        {
            this.postRepository = postRepository;
            this.mainInfoRepository = mainInfoRepository;
            this.additionalInfoRepository = additionalInfoRepository;
            this.vehicleCategoryRepository = vehicleCategoryRepository;
            this.postCategoryRepository = postCategoryRepository;
            this.userManager = userManager;
        }

        public async Task AddPostAsync(AddPostModel model)
        {
            var post = new Post()
            {
                MainInfo = await this.mainInfoRepository.GetByIdWithDeletedAsync(model.MainInfoId),
                AdditionalInfo = await this.additionalInfoRepository.GetByIdWithDeletedAsync(model.AdditionalInfoId),
                AdditionalInfoId = model.AdditionalInfoId,
                MainInfoId = model.MainInfoId,
                CreatedOn = DateTime.UtcNow,
                ApplicationUserId = model.UserId,
                Description = model.Description,
                IsDeleted = false,
                Name = model.Name,
                Make = model.Make,
                Model = model.Model,
                Currency = (Currency)model.Currency,
                PhoneNumber = model.PhoneNumber,
                Price = model.Price,
                VehicleCategoryId = model.VehicleCategoryId,
                VehicleCategory = await this.vehicleCategoryRepository.GetByIdWithDeletedAsync(model.VehicleCategoryId),
                PostCategory = await this.postCategoryRepository.GetByIdWithDeletedAsync(model.PostCategoryId),
                PostCategoryId = model.PostCategoryId,
                IsFavourite = false,
            };

            await this.postRepository.AddAsync(post);
            await this.postRepository.SaveChangesAsync();
        }

        public ICollection<Post> Filter(AllInputSearchViewModel inputModel)
        {
            var posts = this.GetAllPosts().ToList();

            if (inputModel.PostCategory != null && inputModel.PostCategory != "Всички")
            {
                posts = posts
                    .Where(x => x.PostCategory.Name.ToString().ToLower() == inputModel.PostCategory.ToLower())
                    .ToList();
            }

            if (inputModel.Condition != null)
            {
                posts = posts
                    .Where(x => x.Condition.ToString().ToLower() == inputModel.Condition.ToLower())
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
                var isNumber = decimal.TryParse(inputModel.PriceTo, out _);

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
                    var year = new DateTime(int.Parse(modifiedYearFrom), 1, 1);
                    posts = posts
                        .Where(x => x.MainInfo.VehicleCreatedOn >= year)
                        .ToList();
                }
            }

            if (inputModel.YearTo != null)
            {
                var modifiedYearTo = inputModel.YearTo.Replace("до ", string.Empty);

                if (modifiedYearTo != "Всички")
                {
                    var year = new DateTime(int.Parse(modifiedYearTo), 1, 1);
                    posts = posts
                        .Where(x => x.MainInfo.VehicleCreatedOn <= year)
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

            for (int i = 0; i < posts.Count; i++)
            {
                var post = posts[i];
                var allTrueProps = post.AdditionalInfo.SafetyInfo.GetAllTrueProperties.ToList();
                allTrueProps.AddRange(post.AdditionalInfo.OtherInfo.GetAllTrueProperties);
                allTrueProps.AddRange(post.AdditionalInfo.ExteriorInfo.GetAllTrueProperties);
                allTrueProps.AddRange(post.AdditionalInfo.ComfortInfo.GetAllTrueProperties);

                foreach (var checkbox in inputCheckBoxes)
                {
                    if (posts.Count == 0)
                    {
                        break;
                    }

                    if (!allTrueProps.Contains(checkbox))
                    {
                        posts.Remove(post);
                    }
                }
            }

            return posts;
        }

        public ICollection<Post> GetAllPosts()
        {
            return this.postRepository
               .All()
               .ToList();
        }

        public async Task<DetailsViewModel> GetDetailsAsync(string id)
        {
            var post = await this.postRepository.GetByIdWithDeletedAsync(id);
            var imageUrl = post.Images.FirstOrDefault().Url;

            var model = new DetailsViewModel()
            {
                AdditionalInfo = post.AdditionalInfo,
                MainInfo = post.MainInfo,
                Description = post.Description,
                PhoneNumber = post.PhoneNumber,
                PostCategory = post.PostCategory.ToString(),
                VehicleCategory = post.VehicleCategory.Name,
                Id = post.Id,
                ImageUrl = GlobalConstants.CloudinaryLinkWithoutSuffix + imageUrl,
                Name = post.Name,
                Price = post.Price,
                UserId = post.ApplicationUserId,
                UserImageUrl = GlobalConstants.CloudinaryLinkWithoutSuffix + post.ApplicationUser.Image.Url,
            };

            return model;
        }
    }
}
