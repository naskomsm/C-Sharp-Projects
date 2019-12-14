namespace PetStore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PetStore.Services;
    using PetStore.Services.Models.Category;

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

        [HttpGet]
        public IActionResult Info(int id)
        {
            var category = categories.Info(id);

            return View(category);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = categories.GetCategoryById(id);

            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(CategoryDeleteServiceModel model)
        {
            this.categories.Delete(model.Id);

            return RedirectToAction("All");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CategoryAddServiceModel model)
        {
            if(string.IsNullOrEmpty(model.Description) || string.IsNullOrWhiteSpace(model.Description))
            {
                this.categories.Add(model.Name);
            }

            else
            {
                this.categories.Add(model.Name, model.Description);
            }

            return RedirectToAction("All");
        }
    }
}
