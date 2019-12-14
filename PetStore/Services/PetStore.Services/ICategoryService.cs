namespace PetStore.Services
{
    using PetStore.Services.Models.Category;
    using System.Collections.Generic;

    public interface ICategoryService
    {
        IEnumerable<CategoryListingServiceModel> All(int page = 1);

        bool Delete(int id);

        CategoryInfoServiceModel Info(int id);

        CategoryDeleteServiceModel GetCategoryById(int id);

        bool Exists(int categoryId);

        void Add(string name);

        void Add(string name, string description);

        int GetIdByName(string name);
    }
}
