namespace Sabv.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Sabv.Services.Data;
    using Sabv.Web.ViewModels.Category;

    public class CategoriesController : BaseController
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        [HttpGet]
        public IActionResult Display(string name)
        {
            var category = this.categoriesService.GetCategoryByName(name);

            var model = new CategoryViewModel()
            {
                Description = category.Description,
                ImageUrl = category.Image.Url,
                Name = category.Name,
            };

            return this.View("CategoryView", model);
        }
    }
}
