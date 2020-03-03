namespace Sabv.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Sabv.Data.Common.Repositories;
    using Sabv.Data.Models.Categories;
    using Sabv.Data.Models.Cities;
    using Sabv.Data.Models.Extras;
    using Sabv.Data.Models.Posts;
    using Sabv.Web.ViewModels.Posts;

    public class PostsService : IPostsService
    {
        private readonly IRepository<Post> postRepo;
        private readonly IRepository<City> cityRepo;
        private readonly IRepository<Comfort> comfortRepo;
        private readonly IRepository<Other> otherRepo;
        private readonly IRepository<Safety> safetyRepo;
        private readonly IRepository<VehicleCategory> vehicleCategoryRepo;
        private readonly IRepository<Exterior> exteriorRepo;

        public PostsService(
            IRepository<Post> postRepo,
            IRepository<City> cityRepo,
            IRepository<Comfort> comfortRepo,
            IRepository<Other> otherRepo,
            IRepository<Safety> safetyRepo,
            IRepository<VehicleCategory> vehicleCategoryRepo,
            IRepository<Exterior> exteriorRepo)
        {
            this.postRepo = postRepo;
            this.cityRepo = cityRepo;
            this.comfortRepo = comfortRepo;
            this.otherRepo = otherRepo;
            this.safetyRepo = safetyRepo;
            this.vehicleCategoryRepo = vehicleCategoryRepo;
            this.exteriorRepo = exteriorRepo;
        }

        public async Task AddAsync(Post post)
        {
            await this.postRepo.AddAsync(post);
            await this.postRepo.SaveChangesAsync();
        }

        public IEnumerable<Post> GetAll()
        {
            return this.postRepo.All();
        }

        public Post GetById(int id)
        {
            return this.postRepo.All().FirstOrDefault(x => x.Id == id);
        }

        public DetailsViewModel GetDetails(int id)
        {
            var post = this.GetById(id);

            var model = new DetailsViewModel()
            {
                City = this.cityRepo.All().FirstOrDefault(x => x.Id == post.CityId),
                Exterior = this.exteriorRepo.All().FirstOrDefault(x => x.Id == post.ExteriorId),
                Color = post.Color,
                Comfort = this.comfortRepo.All().FirstOrDefault(x => x.Id == post.ComfortId),
                Description = post.Description,
                EngineType = post.EngineType,
                Eurostandard = post.Eurostandard,
                Horsepower = post.Horsepower,
                Id = post.Id,
                Mileage = post.Mileage,
                Name = post.Name,
                Other = this.otherRepo.All().FirstOrDefault(x => x.Id == post.OtherId),
                PhoneNumber = post.PhoneNumber,
                Price = post.Price,
                Safety = this.safetyRepo.All().FirstOrDefault(x => x.Id == post.SafetyId),
                TransmissionType = post.TransmissionType,
                VehicleCategory = this.vehicleCategoryRepo.All().FirstOrDefault(x => x.Id == post.VehicleCategoryId),
                VehicleManufactureDate = post.ManufactureDate,
                Images = post.Images,
            };

            return model;
        }
    }
}
