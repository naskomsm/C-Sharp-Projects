namespace Sabv.Web.Controllers
{
    using System.Linq;
    using System.Security.Claims;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Sabv.Data.Models;
    using Sabv.Services.Data;

    public class CommentsController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICommentsService commentsService;
        private readonly IPostsService postsService;

        public CommentsController(
            UserManager<ApplicationUser> userManager,
            ICommentsService commentsService,
            IPostsService postsService)
        {
            this.userManager = userManager;
            this.commentsService = commentsService;
            this.postsService = postsService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateAsync(string content, int postId)
        {
            if (content.Trim().Length >= 1)
            {
                var userChecker = this.User ?? (ClaimsPrincipal)Thread.CurrentPrincipal;
                var user = await this.userManager.GetUserAsync(userChecker);
                var post = this.postsService.GetAll().FirstOrDefault(x => x.Id == postId);

                await this.commentsService.AddAsync(content, user, post);
            }

            return this.RedirectToAction("Details", "Posts", new { id = postId });
        }

        [Authorize]
        public async Task<IActionResult> LikeAsync(int id, int postId)
        {
            await this.commentsService.Like(id);
            return this.RedirectToAction("Details", "Posts", new { id = postId });
        }
    }
}
