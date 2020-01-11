namespace CarsInfo.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CarsInfo.Data;
    using CarsInfo.Data.Models;
    using CarsInfo.Services.Models.Wheels;

    public class WheelsService : IWheelsService
    {
        private const int pageSize = 6;

        private readonly CarsInfoDbContext data;

        public WheelsService(CarsInfoDbContext data)
        {
            this.data = data;
        }

        public void Add(WheelsAddServiceModel model)
        {
            if (!DataValidation.IsValid(model))
            {
                throw new ArgumentException("Invalid data.");
            }

            var wheels = new Wheels()
            {
                Name = model.Name,
                Used = model.Used,
                Weight = model.Weight,
                Color = model.Color,
                FrontAxleSize = model.FrontAxleSize,
                RearAxleSize = model.RearAxleSize,
                ImageId = model.ImageId,
                Description = model.Description,
                Price = model.Price,
                Image = model.Image
            };

            this.data.Wheels.Add(wheels);
            this.data.SaveChanges();
        }

        public IEnumerable<WheelsListingServiceModel> All(int page = 1)
        {
            return this.data
                .Wheels
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(w => new WheelsListingServiceModel
                {
                    Id = w.Id,
                    Color = w.Color,
                    Image = w.Image,
                    ImageId = w.ImageId,
                    Name = w.Name,
                    Price = w.Price
                })
                .ToList();
        }

        public IEnumerable<WheelsInfoServiceModel> AllInfo()
        {
            return this.data.Wheels
                .Select(x => new WheelsInfoServiceModel
                {
                    Id = x.Id,
                    Image = x.Image,
                    Name = x.Name,
                    Price = x.Price,
                    ImageId = x.ImageId,
                    Color = x.Color,
                    Description = x.Description,
                    FrontAxleSize = x.FrontAxleSize,
                    RearAxleSize = x.FrontAxleSize,
                    Used = x.Used == true ? "Used" : "Brand new",
                    Weight = x.Weight
                });
        }

        public bool Exists(int id)
        {
            return this.data.Wheels.Any(i => i.Id == id);
        }

        public bool Remove(int id)
        {
            if (!this.Exists(id))
            {
                return false;
            }

            var wheels = this.data.Wheels.FirstOrDefault(x => x.Id == id);
            this.data.Wheels.Remove(wheels);
            this.data.SaveChanges();

            return true;
        }

        public int Total()
        {
            return this.data.Wheels.Count();
        }

        public WheelsInfoServiceModel WheelsInfo(int id)
        {
            return this.data.Wheels
                .Where(x => x.Id == id)
                .Select(x => new WheelsInfoServiceModel
                {
                    Id = x.Id,
                    Price = x.Price,
                    Name = x.Name,
                    Description = x.Description,
                    Image = x.Image,
                    ImageId = x.ImageId,
                    Color = x.Color,
                    FrontAxleSize = x.FrontAxleSize,
                    RearAxleSize = x.RearAxleSize,
                    Used = x.Used == true ? "Used" : "Brand new",
                    Weight = x.Weight
                })
                .FirstOrDefault();
        }
    }
}
