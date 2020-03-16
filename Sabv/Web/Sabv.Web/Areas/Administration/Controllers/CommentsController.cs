namespace Sabv.Web.Areas.Administration.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Sabv.Services.Data;
    using Sabv.Web.Controllers;
    using Sabv.Web.ViewModels.Comments;

    [Area("Administration")]
    [Authorize(Roles = "Admin,Moderator")]
    public class CommentsController : BaseController
    {
        private readonly ICommentsService commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            this.commentsService = commentsService;
        }

        public IActionResult Index()
        {
            var model = new CommentsAdminPanel()
            {
                Comments = this.commentsService.GetAll().Where(x => x.Post != null).ToList(),
            };

            return this.View(model);
        }
    }
}
