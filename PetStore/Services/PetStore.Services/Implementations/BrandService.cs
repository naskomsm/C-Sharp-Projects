namespace PetStore.Services.Implementations
{
    using Models.Brand;
    using PetStore.Data;
    using PetStore.Data.Models;
    using PetStore.Services.Models.Toy;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BrandService : IBrandService
    {
        private readonly PetStoreDbContext data;

        // dependency inversion
        public BrandService(PetStoreDbContext data)
            => this.data = data;

        public int Create(string name)
        {
            if (name == null)
            {
                throw new InvalidOperationException("Name cannot be null");
            }

            if (name.Length > DataValidation.NameMaxLength)
            {
                throw new InvalidOperationException($"Name cannot more than {DataValidation.NameMaxLength} characters");
            }

            if (this.data.Brands.Any(b => b.Name == name))
            {
                throw new InvalidOperationException($"Brand with name {name} already exist!");
            }

            var brand = new Brand()
            {
                Name = name
            };

            this.data.Brands.Add(brand);
            this.data.SaveChanges();

            return brand.Id;
        }

        public BrandWithToysServiceModel FindByIdWithToys(int id)
            => this.data
                        .Brands
                        .Where(b => b.Id == id)
                        .Select(b => new BrandWithToysServiceModel
                        {
                            Name = b.Name,
                            Toys = b.Toys.Select(t => new ToyListingServiceModel
                            {
                                Name = t.Name,
                                Price = t.Price,
                                TotalOrders = t.Orders.Count
                            })
                        })
                        .FirstOrDefault();

        public int GetIdByName(string name)
        {
            return this.data
                .Brands
                .Where(x => x.Name == name)
                .Select(x => x.Id)
                .FirstOrDefault();
        }

        public IEnumerable<BrandListingServiceModel> SearchByName(string name)
        {
            return this.data
                .Brands
                .Where(b => b.Name.ToLower().Contains(name.ToLower()))
                .Select(br => new BrandListingServiceModel
                {
                    Id = br.Id,
                    Name = br.Name
                })
                .ToList();
        }
    }
}
