namespace CarsInfo.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CarsInfo.Data;
    using CarsInfo.Data.Models;
    using CarsInfo.Data.Models.Enums.Suspension;
    using CarsInfo.Services.Models.Suspension;

    public class SuspensionService : ISuspensionService
    {
        private const int pageSize = 6;

        private readonly CarsInfoDbContext data;

        public SuspensionService(CarsInfoDbContext data)
        {
            this.data = data;
        }

        public void Add(SuspensionAddServiceModel model)
        {
            var isTypeValid = Enum.IsDefined(typeof(SuspensionType), model.Type);

            if (!isTypeValid)
            {
                throw new ArgumentException("Cannot attach invalid enum to object.");
            }

            if (!DataValidation.IsValid(model))
            {
                throw new ArgumentException("Cannot attach invalid enum to object.");
            }

            var suspension = new Suspension()
            {
                Type = model.Type,
                CarBrandMadeFor = model.CarBrandMadeFor,
                CategoryId = model.CategoryId,
                Category = model.Category,
                ImageId = model.ImageId,
                Image = model.Image,
                Name = model.Name,
                Price = model.Price,
            };

            this.data.Suspensions.Add(suspension);
            this.data.SaveChanges();
        }

        public IEnumerable<SuspensionListingServiceModel> All(int page = 1)
        {
            return this.data
                .Suspensions
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(b => new SuspensionListingServiceModel
                {
                    Id = b.Id,
                    Name = b.Name,
                    Price = b.Price,
                    ImageId = b.ImageId,
                    Image = b.Image
                })
                .ToList();
        }

        public IEnumerable<SuspensionInfoServiceModel> AllInfo()
        {
            return this.data.Suspensions
                .Select(x => new SuspensionInfoServiceModel
                {
                    Id = x.Id,
                    Type = x.Type.ToString(),
                    Price = x.Price,
                    Name = x.Name,
                    CarBrandMadeFor = x.CarBrandMadeFor,
                    Category = x.Category,
                    CategoryId = x.CategoryId,
                    Image = x.Image,
                    ImageId = x.ImageId
                });

        }

        public bool Exists(int id)
        {
            return this.data.Suspensions.Any(s => s.Id == id);
        }

        public bool Remove(int id)
        {
            if (!this.Exists(id))
            {
                return false;
            }

            var suspension = this.data.Suspensions.FirstOrDefault(x => x.Id == id);
            this.data.Suspensions.Remove(suspension);
            this.data.SaveChanges();

            return true;
        }

        public SuspensionInfoServiceModel SuspensionInfo(int id)
        {
            return this.data.Suspensions
                .Where(x => x.Id == id)
                .Select(x => new SuspensionInfoServiceModel
                {
                    Id = x.Id,
                    Type = x.Type.ToString(),
                    Price = x.Price,
                    Name = x.Name,
                    CarBrandMadeFor = x.CarBrandMadeFor,
                    Category = x.Category,
                    CategoryId = x.CategoryId,
                    Image = x.Image,
                    ImageId = x.ImageId
                })
                .FirstOrDefault();
        }

        public int Total()
        {
            return this.data.Suspensions.Count();
        }
    }
}
