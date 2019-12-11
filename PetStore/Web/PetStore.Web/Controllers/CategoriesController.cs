namespace PetStore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PetStore.Services;

    public class CategoriesController : Controller
    {
        private readonly ICategoryService categories;

        public CategoriesController(ICategoryService categories)
        {
            this.categories = categories;
        }

        [HttpGet]
        public IActionResult All(int page = 1)
        {
            var allPets = this.categories.All(page);

            return View(allPets);
        }
    }
}
