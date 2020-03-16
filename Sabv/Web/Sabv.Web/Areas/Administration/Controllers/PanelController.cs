namespace Sabv.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Sabv.Common;
    using Sabv.Web.Controllers;

    [Area("Administration")]
    [Authorize(Roles = "Admin,Moderator")]
    public class PanelController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
