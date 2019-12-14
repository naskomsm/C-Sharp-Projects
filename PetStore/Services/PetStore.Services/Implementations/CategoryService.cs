namespace PetStore.Services.Implementations
{
    using PetStore.Data;
    using PetStore.Data.Models;
    using PetStore.Services.Models.Category;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CategoryService : ICategoryService
    {
        private const int PetsPageSize = 25;

        private readonly PetStoreDbContext data;

        public CategoryService(PetStoreDbContext data)
        {
            this.data = data;
        }

        public void Add(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Category name cannot be null or whitespace");
            }

            var category = new Category()
            {
                Name = name
            };

            this.data.Categories.Add(category);
            this.data.SaveChanges();
        }

        public void Add(string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Category name cannot be null or whitespace");
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Category description cannot be null or whitespace");
            }

            var category = new Category()
            {
                Name = name,
                Description = description
            };

            this.data.Categories.Add(category);
            this.data.SaveChanges();
        }

        public IEnumerable<CategoryListingServiceModel> All(int page = 1)
        {
            return this.data
                .Categories
                .Skip((page - 1) * PetsPageSize)
                .Select(c => new CategoryListingServiceModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();
        }

        public CategoryDeleteServiceModel GetCategoryById(int id)
        {
            return this.data
                .Categories
                .Where(c => c.Id == id)
                .Select(c => new CategoryDeleteServiceModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .FirstOrDefault();
        }

        public bool Exists(int categoryId)
        {
            return this.data.Categories.Any(x => x.Id == categoryId);
        }

        public int GetIdByName(string name)
        {
            return this.data
                .Categories
                .Where(x => x.Name == name)
                .Select(x => x.Id)
                .FirstOrDefault();
        }

        public CategoryInfoServiceModel Info(int id)
        {
            return this.data
               .Categories
               .Where(c => c.Id == id)
               .Select(c => new CategoryInfoServiceModel
               {
                   Id = c.Id,
                   Name = c.Name,
                   Description = c.Description
               })
               .FirstOrDefault();
        }

        public bool Delete(int id)
        {
            var category = this.data.Categories.Find(id);

            this.data.Categories.Remove(category);
            this.data.SaveChanges();

            return true;
        }
    }
}
