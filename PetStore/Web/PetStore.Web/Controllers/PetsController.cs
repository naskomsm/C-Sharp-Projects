namespace PetStore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services;
    using Services.Models.Pet;

    public class PetsController : Controller
    {
        private readonly IPetService pets;

        public PetsController(IPetService pets)
        {
            this.pets = pets;
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
        public IActionResult Add(PetAddServiceModel model)
        {


            return View(model);
        }
    }
}