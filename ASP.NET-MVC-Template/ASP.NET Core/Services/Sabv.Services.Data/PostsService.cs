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
