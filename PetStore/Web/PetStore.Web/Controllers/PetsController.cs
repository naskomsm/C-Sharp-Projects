namespace PetStore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Data.Models.enums;
    using Services;
    using Services.Models.Pet;
    using System;
    using System.Globalization;

    public class PetsController : Controller
    {
        private readonly IPetService pets;
        private readonly IBreedService breeds;
        private readonly ICategoryService categories;

        public PetsController(IPetService pets, IBreedService breeds, ICategoryService categories)
        {
            this.pets = pets;
            this.breeds = breeds;
            this.categories = categories;
        }

        [HttpGet]
        public IActionResult All(int page = 1)
        {
            var allPets = this.pets.All(page);

            return View(allPets);
        }

        [HttpGet]
        public IActionResult Info(int id)
        {
            var pet = pets.PetInfo(id);

            return View(pet);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var pet = pets.GetPetById(id);

            return View(pet);
        }

        [HttpPost]
        public IActionResult Delete(PetDeleteServiceModel model)
        {
            this.pets.Delete(model.Id);

            return RedirectToAction("All");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PetAddServiceModel model)
        {
            var breedId = this.breeds.GetIdByName(model.Breed);
            var categoryId = this.categories.GetIdByName(model.Category);

            if (breedId == 0)
            {
                throw new ArgumentException("This breed does not exist in database");
            }

            if (categoryId == 0)
            {
                throw new ArgumentException("This category does not exist in database");
            }

            var birthdate = DateTime.ParseExact(model.BirthDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var isGenderValid = Enum.TryParse(model.Gender, out Gender _);
            
            if (isGenderValid == false)
            {
                throw new ArgumentNullException("Gender is invalid/NULL");
            }
            
            var gender = (Gender)Enum.Parse(typeof(Gender), model.Gender, true);

            this.pets.BuyPet(gender, birthdate, model.Price, model.Description, breedId, categoryId);

            return RedirectToAction("All");
        }
    }
}