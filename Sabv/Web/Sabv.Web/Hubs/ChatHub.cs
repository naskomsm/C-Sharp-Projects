namespace Sabv.Web.Hubs
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.SignalR;
    using Sabv.Common;
    using Sabv.Data.Models;
    using Sabv.Services.Data;

    public class ChatHub : Hub
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMessagesService messagesService;
        private readonly IPostsService postsService;
        private readonly ICommentsService commentsService;

        public ChatHub(
            UserManager<ApplicationUser> userManager,
            IMessagesService messagesService,
            IPostsService postsService,
            ICommentsService commentsService)
        {
            this.userManager = userManager;
            this.messagesService = messagesService;
            this.postsService = postsService;
            this.commentsService = commentsService;
        }

        [Authorize]
        public async Task SendMessage(string message)
        {
            if (message.Trim().Length < 1)
            {
                return;
            }

            var user = await this.userManager.GetUserAsync(this.Context.User);
            var currentUserImageUrl = GlobalConstants.BaseCloudinaryLink + user.Image.Url;

            await this.messagesService.AddAsync(message, user);

            await this.Clients.All.SendAsync("ReceiveMessage", user.UserName.Substring(0, user.UserName.IndexOf("@")), message, currentUserImageUrl);
        }

        [Authorize]
        public async Task SendComment(string content, string postId)
        {
            if (content.Trim().Length < 1)
            {
                return;
            }

            var user = await this.userManager.GetUserAsync(this.Context.User);
            var currentUserImageUrl = GlobalConstants.BaseCloudinaryLink + user.Image.Url;

            var post = this.postsService.GetAll().FirstOrDefault(x => x.Id == int.Parse(postId));
            var commentId = await this.commentsService.AddAsync(content, user, post);

            await this.Clients.All.SendAsync("PostComment", user.UserName.Substring(0, user.UserName.IndexOf("@")), content, currentUserImageUrl, commentId);
        }

        [Authorize]
        public async Task LikeComment(string commentId)
        {
            await this.commentsService.Like(int.Parse(commentId));
            var commentLikes = this.commentsService.GetAll().FirstOrDefault(x => x.Id == int.Parse(commentId)).Likes;
            await this.Clients.All.SendAsync("LikeComment");
        }
    }
}
