namespace Sabv.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Sabv.Services.Data;
    using Sabv.Web.Controllers;
    using Sabv.Web.ViewModels.Chat;

    [Area("Administration")]
    [Authorize(Roles = "Admin,Moderator")]
    public class ChatController : BaseController
    {
        private readonly IMessagesService messagesService;

        public ChatController(IMessagesService messagesService)
        {
            this.messagesService = messagesService;
        }

        public IActionResult Index()
        {
            var mdoel = new MessagesAdminPanel()
            {
                Messages = this.messagesService.GetAll().ToList(),
            };

            return this.View(mdoel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.messagesService.DeleteAsync(id);
            return this.RedirectToAction("Index");
        }
    }
}
