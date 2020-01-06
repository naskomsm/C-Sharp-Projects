namespace CarsInfo.Services.Implementations
{
    using System;
    using System.Linq;
    using CarsInfo.Data;
    using CarsInfo.Data.Models;
    using CarsInfo.Services.Models.Wheels;

    public class WheelsService : IWheelsService
    {
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
                Image = model.Image
            };

            this.data.Wheels.Add(wheels);
            this.data.SaveChanges();
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
    }
}
