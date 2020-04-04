namespace Sabv.Services.Data
{
    using System.Threading.Tasks;

    using Sabv.Data.Models;

    public interface IUsersService
    {
        Task SetProfilePictureAsync(Image image, string userId);
    }
}
