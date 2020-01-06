namespace CarsInfo.Services
{
    using CarsInfo.Services.Models.Category;

    public interface ICategoryService
    {
        bool Exists(int id);

        void Add(CategoryAddServiceModel model);

        bool Remove(int id);
    }
}
