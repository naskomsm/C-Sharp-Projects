﻿namespace Sabv.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Sabv.Common;
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
        public async Task<IActionResult> Chat()
        {
            var email = this.HttpContext.User.Identities.FirstOrDefault().Name;

            var model = new ChatViewModel()
            {
                Messages = this.messagesService.GetAll().ToList(),
                User = await this.userManager.FindByEmailAsync(email),
            };

            this.ViewBag.CurrentUser = model.User;
            this.ViewBag.CurrentUserImage = GlobalConstants.BaseCloudinaryLink + model.User.Image.Url;

            return this.View(model);
        }
    }
}
