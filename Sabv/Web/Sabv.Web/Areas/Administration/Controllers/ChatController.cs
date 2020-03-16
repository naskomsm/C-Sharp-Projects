namespace Sabv.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Sabv.Common;
    using Sabv.Web.Controllers;

    [Area("Administration")]
    [Authorize(Roles = GlobalConstants.User.AdminRole)]
    [Authorize(Roles = GlobalConstants.User.ModeratorRole)]
    public class ChatController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
