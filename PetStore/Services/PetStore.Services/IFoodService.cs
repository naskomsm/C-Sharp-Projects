namespace PetStore.Services
{
    using PetStore.Services.Models.Food;
    using System;

    public interface IFoodService
    {
        void BuyFromDistributor(string name, double weight,double profit, decimal price, 
            DateTime expireDate, int brandId, int categoryId);

        void BuyFromDistributor(AddingFoodServiceModel model);

        void SellFoodToUser(int foodId, int userId);

        bool Exists(int foodId);

        int GetIdByName(string name);
    }
}
