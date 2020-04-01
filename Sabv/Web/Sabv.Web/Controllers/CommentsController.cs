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
    using Sabv.Web.ViewModels.Comments;

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

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<CommentResponseModel>> Create(CommentInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Details", "Posts", new { id = input.PostId });
            }

            var userChecker = this.User ?? (ClaimsPrincipal)Thread.CurrentPrincipal;
            var user = await this.userManager.GetUserAsync(userChecker);
            var post = this.postsService.GetAll().FirstOrDefault(x => x.Id == input.PostId);

            var commentId = await this.commentsService.AddAsync(input.Content, user, post);

            return new CommentResponseModel { Content = input.Content, CommentId = commentId, Username = user.UserName, CurrentUserImageUrl = user.Image.Url, PostId = input.PostId };
        }

        [HttpGet]
        [Authorize]
        public async Task<int> Like(int commentId)
        {
            var userChecker = this.User ?? (ClaimsPrincipal)Thread.CurrentPrincipal;
            var user = await this.userManager.GetUserAsync(userChecker);
            var comment = this.commentsService.GetAll().FirstOrDefault(x => x.Id == commentId);

            if (!comment.UserLikes.Any(x => x.UserId == user.Id && x.CommentId == commentId))
            {
                await this.commentsService.Like(commentId, user);
            }

            return commentId;
        }

        [HttpGet]
        public int GetLikes(int commentId)
        {
            var comment = this.commentsService.GetAll().FirstOrDefault(x => x.Id == commentId);
            return comment.UserLikes.Count;
        }
    }
}
