namespace PetStore.Services.Implementations
{
    using Models.Brand;
    using PetStore.Data;
    using PetStore.Data.Models;
    using PetStore.Services.Models.Food;
    using PetStore.Services.Models.Toy;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BrandService : IBrandService
    {
        private readonly PetStoreDbContext data;

        public BrandService(PetStoreDbContext data)
            => this.data = data;

        public IEnumerable<BrandListingServiceModel> All(int page = 1)
        {
            return this.data
                .Brands
                .Skip((page - 1) * page)
                .Select(c => new BrandListingServiceModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();
        }

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

        public BrandInfoLIstingServiceModel Info(int id)
            => this.data
                        .Brands
                        .Where(b => b.Id == id)
                        .Select(b => new BrandInfoLIstingServiceModel
                        {
                            Id = b.Id,
                            Name = b.Name,
                            Toys = b.Toys.Select(t => new ToyListingServiceModel
                            {
                                Id = t.Id,
                                Name = t.Name,
                                Price = t.Price,
                                TotalOrders = t.Orders.Count
                            }),
                            Food = b.Food.Select(f => new FoodListingServiceModel 
                            {
                                Id = f.Id,
                                Name = f.Name,
                                ExpireDate = f.ExpireDate.ToString("dd/MMMM/yyyy"),
                                Price = f.Price,
                                Weight = f.Weight
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

        public void Add(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("brand name cannot be null or whitespace");
            }

            var brand = new Brand()
            {
                Name = name,
                Food = new List<Food>(),
                Toys = new List<Toy>()
            };

            this.data.Brands.Add(brand);
            this.data.SaveChanges();
        }

        public BrandDeleteServiceModel GetBrandById(int id)
        {
            return this.data
                .Brands
                .Where(b => b.Id == id)
                .Select(b => new BrandDeleteServiceModel
                {
                    Id = b.Id,
                    Name = b.Name
                })
                .FirstOrDefault();
        }

        public bool Delete(int id)
        {
            var brandToDelete = this.data.Brands.Find(id);

            this.data.Brands.Remove(brandToDelete);
            this.data.SaveChanges();

            return true;
        }
    }
}
