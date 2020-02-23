namespace Sabv.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Sabv.Common;
    using Sabv.Data.Common.Repositories;
    using Sabv.Data.Models;
    using Sabv.Services.Data.Contracts;
    using Sabv.Services.Models.Posts;
    using Sabv.Web.ViewModels.Posts;

    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<Post> postRepository;

        public PostsService(IDeletableEntityRepository<Post> postRepository)
        {
            this.postRepository = postRepository;
        }

        public async Task AddPost()
        {
            throw new System.NotImplementedException();
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

        public async Task<PostDetailsModel> GetDetailsAsync(string id)
        {
            var post = await this.postRepository.GetByIdWithDeletedAsync(id);

            var model = new PostDetailsModel()
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
            };

            return model;
        }
    }
}
