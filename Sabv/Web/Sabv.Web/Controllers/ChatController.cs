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
    using Sabv.Web.ViewModels.Chat;

    public class ChatController : BaseController
    {
        private readonly IMessagesService messagesService;
        private readonly UserManager<ApplicationUser> userManager;

        public ChatController(IMessagesService messagesService, UserManager<ApplicationUser> userManager)
        {
            this.messagesService = messagesService;
            this.userManager = userManager;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Main()
        {
            var user = this.User ?? (ClaimsPrincipal)Thread.CurrentPrincipal;

            var model = new ChatViewModel()
            {
                Messages = this.messagesService.GetAll().ToList(),
                User = await this.userManager.GetUserAsync(user),
            };

            return this.View("Chat", model);
        }
    }
}
