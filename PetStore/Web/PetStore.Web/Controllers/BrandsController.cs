namespace PetStore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services;
    using Services.Models.Brand;
    using System;

    public class BrandsController : Controller
    {
        private readonly IBrandService brands;

        public BrandsController(IBrandService brands)
        {
            this.brands = brands;
        }

        [HttpGet]
        public IActionResult All(int page = 1)
        {
            var allBrands = this.brands.All(page);

            return View(allBrands);
        }

        [HttpGet]
        public IActionResult Info(int id)
        {
            var brand = this.brands.Info(id);

            return View(brand);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(BrandAddServiceModel model)
        {
            if(string.IsNullOrEmpty(model.Name) || string.IsNullOrWhiteSpace(model.Name))
            {
                throw new ArgumentException("Name of brand cannot be null or whitespace!");
            }

            this.brands.Add(model.Name);

            return RedirectToAction("All");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var brand = this.brands.GetBrandById(id);

            return View(brand);
        }

        [HttpPost]
        public IActionResult Delete(BrandDeleteServiceModel model)
        {
            this.brands.Delete(model.Id);

            return RedirectToAction("All");
        }
    }
}
