namespace Sabv.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using Sabv.Data.Common.Repositories;
    using Sabv.Data.Models;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepo;

        public UsersService(IDeletableEntityRepository<ApplicationUser> usersRepo)
        {
            this.usersRepo = usersRepo;
        }

        public async Task SetProfilePictureAsync(Image image, string userId)
        {
            var user = this.usersRepo.All().FirstOrDefault(x => x.Id == userId);
            user.Image = image;
            user.ImageId = image.Id;
            await this.usersRepo.SaveChangesAsync();
        }
    }
}
