namespace PetStore.Services.Implementations
{
    using PetStore.Data;
    using PetStore.Data.Models;
    using System;
    using System.Linq;

    public class CategoryService : ICategoryService
    {
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
    }
}
