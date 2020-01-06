namespace CarsInfo.Services.Implementations
{
    using System;
    using System.Linq;
    using CarsInfo.Data;
    using CarsInfo.Data.Models;
    using CarsInfo.Services.Models.Category;

    public class CategoryService : ICategoryService
    {
        private readonly CarsInfoDbContext data;

        public CategoryService(CarsInfoDbContext data)
        {
            this.data = data;
        }

        public void Add(CategoryAddServiceModel model)
        {
            if (!DataValidation.IsValid(model))
            {
                throw new ArgumentException("Invalid data.");
            }

            var category = new Category()
            {
                Name = model.Name
            };

            if(!string.IsNullOrEmpty(model.Description) && !string.IsNullOrWhiteSpace(model.Description))
            {
                category.Description = model.Description;
            }

            this.data.Categories.Add(category);
            this.data.SaveChanges();
        }

        public bool Exists(int id)
        {
            return this.data.Categories.Any(c => c.Id == id);
        }

        public bool Remove(int id)
        {
            if (!this.Exists(id))
            {
                return false;
            }

            var category = this.data.Categories.FirstOrDefault(x => x.Id == id);
            this.data.Categories.Remove(category);
            this.data.SaveChanges();

            return true;
        }
    }
}
