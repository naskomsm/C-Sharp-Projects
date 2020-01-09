namespace CarsInfo.Services.Implementations
{
    using System;
    using System.Linq;
    using CarsInfo.Data;
    using CarsInfo.Data.Models;
    using CarsInfo.Services.Models.Brakes;
    using CarsInfo.Data.Models.Enums.Brakes;
    using System.Collections.Generic;

    public class BrakesService : IBrakesService
    {
        private const int pageSize = 6;

        private readonly CarsInfoDbContext data;

        public BrakesService(CarsInfoDbContext data)
        {
            this.data = data;
        }

        public void Add(BrakesAddServiceModel model)
        {
            var isTypeValid = Enum.IsDefined(typeof(BrakesType), model.Type);

            if (!isTypeValid)
            {
                throw new ArgumentException("Cannot attach invalid enum to object.");
            }

            var brakes = new Brakes()
            {
                Type = model.Type,
                Description = model.Description,
                Used = model.Used,
                Name = model.Name,
                Price = model.Price,
                ImageId = model.ImageId,
                Image = model.Image
            };

            if(model.Image != null)
            {
                brakes.Image = model.Image;
            }

            this.data.Brakes.Add(brakes);
            this.data.SaveChanges();
        }

        public IEnumerable<BrakesListingServiceModel> All(int page = 1)
        {
            return this.data
                .Brakes
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(b => new BrakesListingServiceModel
                {
                    Id = b.Id,
                    Type = b.Type.ToString(),
                    Name = b.Name,
                    Price = b.Price,
                    ImageId = b.ImageId,
                    Image = b.Image
                })
                .ToList();
        }

        public IEnumerable<BrakesInfoServiceModel> AllInfo()
        {
            return this.data.Brakes.Select(x => new BrakesInfoServiceModel
            {
                Id = x.Id,
                Description = x.Description,
                Image = x.Image,
                Name = x.Name,
                Price = x.Price,
                ImageId = x.ImageId,
                Type = x.Type.ToString(),
                Used = x.Used == true ? "Used" : "Brand new"
            });
        }

        public BrakesInfoServiceModel BrakesInfo(int id)
        {
            return this.data.Brakes
                .Where(x => x.Id == id)
                .Select(x => new BrakesInfoServiceModel
                {
                    Id = x.Id,
                    Used = x.Used == true ? "Used" : "Brand new",
                    Type = x.Type.ToString(),
                    Price = x.Price,
                    Name = x.Name,
                    Description = x.Description,
                    Image = x.Image,
                    ImageId = x.ImageId
                })
                .FirstOrDefault();
        }

        public bool Exists(int id)
        {
            return this.data.Brakes.Any(b => b.Id == id);
        }

        public bool Remove(int id)
        {
            if (!this.Exists(id))
            {
                return false;
            }

            var brakes = this.data.Brakes.FirstOrDefault(x => x.Id == id);
            this.data.Brakes.Remove(brakes);
            this.data.SaveChanges();

            return true;
        }

        public int Total()
        {
            return this.data.Brakes.Count();
        }
    }
}
