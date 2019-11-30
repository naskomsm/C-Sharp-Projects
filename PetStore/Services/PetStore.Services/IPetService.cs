namespace PetStore.Services
{
    using System;
    using PetStore.Data.Models.enums;

    public interface IPetService
    {
        void BuyPet(Gender gender, DateTime birthdate, decimal price, string description, 
            int breedId, int categoryId);

        void SellPet(int petId, int userId);

        bool Exists(int petId);
    }
}
