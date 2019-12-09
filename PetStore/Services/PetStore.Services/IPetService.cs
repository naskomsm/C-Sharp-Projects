namespace PetStore.Services
{
    using System;
    using System.Collections.Generic;
    using Data.Models.enums;
    using Models.Pet;

    public interface IPetService
    {
        PetInfoServiceModel PetInfo(int id);

        PetDeleteServiceModel GetPetById(int id);

        bool Delete(int id);

        IEnumerable<PetListingServiceModel> All(int page = 1);

        void BuyPet(Gender gender, DateTime birthdate, decimal price, string description, 
            int breedId, int categoryId);

        void SellPet(int petId, int userId);

        bool Exists(int petId);
    }
}
