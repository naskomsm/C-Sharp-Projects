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

        public ICollection<PostViewModel> GetAllPosts()
        {
            return this.postRepository
               .All()
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
               .ToList();
        }

        public async Task<DetailsViewModel> GetDetailsAsync(string id)
        {
            var post = await this.postRepository.GetByIdWithDeletedAsync(id);

            var model = new DetailsViewModel()
            {
                ABS = post.AdditionalInfo.ABS,
                Airbags = post.AdditionalInfo.Airbags,
                AirSuspension = post.AdditionalInfo.AirSuspension,
                AllWheelDrive = post.AdditionalInfo.AllWheelDrive,
                Barter = post.AdditionalInfo.Barter,
                ClimateControl = post.AdditionalInfo.ClimateControl,
                Color = post.MainInfo.Color,
                Description = post.Description,
                ElectricMirrors = post.AdditionalInfo.ElectricMirrors,
                ElectricWindows = post.AdditionalInfo.ElectricWindows,
                EngineType = post.MainInfo.EngineType.ToString(),
                FiveDoors = post.AdditionalInfo.FiveDoors,
                GPS = post.AdditionalInfo.GPS,
                HorsePower = post.MainInfo.HorsePower,
                Id = post.Id,
                Mileage = post.MainInfo.Mileage,
                Name = post.Name,
                Parktronic = post.AdditionalInfo.Parktronic,
                PhoneNumber = post.PhoneNumber,
                Price = post.Price,
                RainSensor = post.AdditionalInfo.RainSensor,
                StartStopFunction = post.AdditionalInfo.StartStopFunction,
                ThreeDoors = post.AdditionalInfo.ThreeDoors,
                Town = post.AdditionalInfo.Town,
                TractionControl = post.AdditionalInfo.TractionControl,
                TransmissionType = post.MainInfo.TransmissionType.ToString(),
                Tuned = post.AdditionalInfo.Tuned,
                USBAudio = post.AdditionalInfo.USBAudio,
                VehicleCreatedOn = post.MainInfo.VehicleCreatedOn,
                UserId = post.ApplicationUser.Id,
                UserImageId = post.ApplicationUser.Image.Id,
                UserImageUrl = post.ApplicationUser.Image.Url,
            };

            return model;
        }
    }
}
