namespace PetStore.Services.Implementations
{
    using PetStore.Data;
    using PetStore.Data.Models;
    using PetStore.Data.Models.enums;
    using PetStore.Services.Models.Pet;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class PetService : IPetService
    {
        private const int PetsPageSize = 25;

        private readonly PetStoreDbContext data;
        private readonly ICategoryService categoryService;
        private readonly IBreedService breedService;
        private readonly IUserService userService;

        public PetService(PetStoreDbContext data, 
            ICategoryService categoryService, 
            IBreedService breedService,
            IUserService userService)
        {
            this.data = data;
            this.categoryService = categoryService;
            this.breedService = breedService;
            this.userService = userService;
        }

        public void BuyPet(Gender gender, DateTime birthdate, decimal price, string description, 
            int breedId, int categoryId)
        {
            if(price < 0)
            {
                throw new ArgumentException("Price of the pet cannot be less 0");
            }

            if (!this.breedService.Exists(breedId))
            {
                throw new ArgumentException("There is no such breed with given id!");
            }

            if (!this.categoryService.Exists(categoryId))
            {
                throw new ArgumentException("There is no such category with given id!");
            }

            var pet = new Pet()
            {
                Gender = gender,
                BirthDate = birthdate,
                Price = price,
                Description = description,
                BreedId = breedId,
                CategoryId = categoryId
            };

            this.data.Pets.Add(pet);
            this.data.SaveChanges();
        }

        public void SellPet(int petId, int userId)
        {
            if (!this.userService.Exists(userId))
            {
                throw new ArgumentException("There is no such user with given id");
            }

            if (!this.Exists(petId))
            {
                throw new ArgumentException("There is no such pet with given id");
            }

            var pet = this.data.Pets.FirstOrDefault(p => p.Id == petId);

            var order = new Order()
            {
                PurchaseDate = DateTime.Now,
                Status = OrderStatus.Done,
                UserId = userId
            };

            this.data.Orders.Add(order);
            pet.Order = order;
            this.data.SaveChanges();
        }

        public bool Exists(int petId)
        {
            return this.data.Pets.Any(x => x.Id == petId);
        }

        public IEnumerable<PetListingServiceModel> All(int page = 1)
        {
            return this.data
                .Pets
                .Skip((page - 1) * PetsPageSize)
                .Take(PetsPageSize)
                .Select(p => new PetListingServiceModel
                {
                    Id = p.Id,
                    Price = p.Price,
                    Category = p.Category.Name,
                    Breed = p.Breed.Name
                })
                .ToList();
        }

        public PetInfoServiceModel PetInfo(int id)
        {
            return this.data
                .Pets
                .Where(p => p.Id == id)
                .Select(p => new PetInfoServiceModel
                {
                    Id = p.Id,
                    Age = p.Age,
                    BirthDate = p.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Breed = p.Breed.Name,
                    Category = p.Category.Name,
                    Description = p.Description,
                    Gender = p.Gender.ToString(),
                    Price = p.Price
                })
                .FirstOrDefault();
        }
    }
}
