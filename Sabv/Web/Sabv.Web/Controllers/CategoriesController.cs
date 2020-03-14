namespace Sabv.Web.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using Sabv.Common;
    using Sabv.Services.Data;
    using Sabv.Web.ViewModels.Posts;

    public class CategoriesController : BaseController
    {
        private readonly IPostsService postsService;

        public CategoriesController(IPostsService postsService)
        {
            this.postsService = postsService;
        }

        [HttpGet]
        public IActionResult PostsByCategories(string name)
        {
            var postsByCategories = this.postsService
                .GetAll<AllPagePostViewModel>()
                .Where(x => x.Category.Name == name)
                .ToList();

            var viewModel = new AllPageViewModel()
            {
                Posts = postsByCategories,
            };

            return this.View("../Posts/All", viewModel);
        }
    }
}
