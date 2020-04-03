namespace Sabv.Web.Hubs
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.SignalR;
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
            var currentUserImageUrl = user.Image.Url;

            var messageId = await this.messagesService.AddAsync(message, user);
            var messageEntity = this.messagesService.GetAll().FirstOrDefault(x => x.Id == messageId);
            await this.Clients.All.SendAsync("ReceiveMessage", user.UserName, message, currentUserImageUrl, messageEntity.CreatedOn);
        }
    }
}
