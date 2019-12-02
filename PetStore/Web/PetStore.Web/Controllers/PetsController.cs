namespace PetStore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PetStore.Services;

    public class PetsController : Controller
    {
        private readonly IPetService pets;

        public PetsController(IPetService pets)
        {
            this.pets = pets;
        }

        public IActionResult All(int page = 1)
        {
            var allPets = this.pets.All(page);

            return View(allPets);
        }

        public IActionResult Info(int id)
        {
            var pet = pets.PetInfo(id);

            return View(pet);
        }
    }
}