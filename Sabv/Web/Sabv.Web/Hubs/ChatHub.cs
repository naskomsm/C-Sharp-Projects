namespace Sabv.Web.Hubs
{
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

        public ChatHub(
            UserManager<ApplicationUser> userManager,
            IMessagesService messagesService)
        {
            this.userManager = userManager;
            this.messagesService = messagesService;
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
    }
}
