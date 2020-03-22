namespace Sabv.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Sabv.Services.Data;
    using Sabv.Web.Controllers;
    using Sabv.Web.ViewModels.Posts;

    [Area("Administration")]
    [Authorize(Roles = "Admin")]
    public class PostsController : BaseController
    {
        private readonly IPostsService postsService;

        public PostsController(IPostsService postsService)
        {
            this.postsService = postsService;
        }

        public IActionResult Index()
        {
            var model = new PostsAdminPanel()
            {
                Posts = this.postsService.GetAll().ToList(),
            };

            return this.View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.postsService.DeleteAsync(id);
            return this.RedirectToAction("Index");
        }
    }
}
