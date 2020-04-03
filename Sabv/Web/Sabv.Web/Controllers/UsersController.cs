namespace Sabv.Web.Controllers
{
    using System.Linq;
    using System.Security.Claims;
    using System.Threading;
    using System.Threading.Tasks;

    using cloudscribe.Pagination.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Sabv.Data.Models;
    using Sabv.Services.Data;
    using Sabv.Services.Mapping;
    using Sabv.Web.ViewModels.Favourites;

    public class UsersController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IFavouritesService favouritesService;

        public UsersController(UserManager<ApplicationUser> userManager, IFavouritesService favouritesService)
        {
            this.userManager = userManager;
            this.favouritesService = favouritesService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Favourites(int pageNumber = 1, int pageSize = 15)
        {
            var excludeRecords = (pageSize * pageNumber) - pageSize;

            var userChecker = this.User ?? (ClaimsPrincipal)Thread.CurrentPrincipal;
            var user = await this.userManager.GetUserAsync(userChecker);

            var favouritePosts = this.favouritesService
                .GetAllUserFavourites(user.Id)
                .Where(x => x.Post != null)
                .Select(x => x.Post)
                .AsQueryable()
                .Skip(excludeRecords)
                .Take(pageSize)
                .To<FavouriteViewModel>();

            var model = new PagedResult<FavouriteViewModel>()
            {
                Data = favouritePosts.AsNoTracking().ToList(),
                TotalItems = favouritePosts.Count(),
                PageNumber = pageNumber,
                PageSize = pageSize,
            };

            return this.View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddFavouriteAsync(int id)
        {
            var userChecker = this.User ?? (ClaimsPrincipal)Thread.CurrentPrincipal;
            var user = await this.userManager.GetUserAsync(userChecker);

            if (!this.favouritesService.GetAllUserFavourites(user.Id).Any(x => x.PostId == id))
            {
                await this.favouritesService.AddAsync(id, user.Id);
            }

            return this.RedirectToAction("Details", "Posts", new { id });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> RemoveFavouriteAsync(int id)
        {
            var userChecker = this.User ?? (ClaimsPrincipal)Thread.CurrentPrincipal;
            var user = await this.userManager.GetUserAsync(userChecker);
            await this.favouritesService.Remove(id, user.Id);
            return this.RedirectToAction("Favourites", "Users");
        }

        [HttpGet]
        public bool IsUserLoggedIn()
        {
            return this.User.Identity.Name != null;
        }
    }
}
