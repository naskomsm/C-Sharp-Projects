namespace CarsInfo.Services.Implementations
{
    using CarsInfo.Data;
    using CarsInfo.Data.Models;
    using CarsInfo.Data.Models.Enums.Car;
    using CarsInfo.Services.Models.Car;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CarService : ICarService
    {
        private const int pageSize = 6;

        private readonly CarsInfoDbContext data;

        public CarService(CarsInfoDbContext data)
        {
            this.data = data;
        }

        public void Add(CarAddServiceModel model)
        {
            var isEmissionStandartValid = Enum.IsDefined(typeof(EmissionStandard), model.EmissionStandard);
            var isWheelDriveValid = Enum.IsDefined(typeof(WheelDrive), model.WheelDrive);

            if (!isEmissionStandartValid || !isWheelDriveValid)
            {
                throw new ArgumentException("Cannot attach invalid enum to object.");
            }

            if (!DataValidation.IsValid(model))
            {
                throw new ArgumentException("Invalid data.");
            }

            var car = new Car()
            {
                Brand = model.Brand,
                Model = model.Model,
                Generation = model.Generation,
                Color = model.Color,
                Price = model.Price,
                YearStart = model.YearStart,
                YearEnd = model.YearEnd,
                Seats = model.Seats,
                Doors = model.Doors,
                Length = model.Length,
                Width = model.Width,
                Height = model.Height,
                FuelConsumption = model.FuelConsumption,
                Weight = model.Weight,
                MaxWeight = model.MaxWeight,
                EmissionStandard = model.EmissionStandard,
                CategoryId = model.CategoryId,
                Category = model.Category,
                EngineId = model.EngineId,
                Engine = model.Engine,
                ImageId = model.ImageId,
                Image = model.Image,
                ABS = model.ABS,
                WheelDrive = model.WheelDrive,
                WheelsId = model.WheelsId,
                Wheels = model.Wheels,
                SuspensionId = model.SuspensionId,
                Suspension = model.Suspension,
                BrakesId = model.BrakesId,
                Brakes = model.Brakes
            };

            this.data.Cars.Add(car);
            this.data.SaveChanges();
        }

        public IEnumerable<CarListingServiceModel> All(int page = 1)
        {
            return this.data
                .Cars
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(c => new CarListingServiceModel
                {
                    Id = c.Id,
                    Price = c.Price,
                    ImageId = c.ImageId,
                    Image = c.Image,
                    Brand = c.Brand,
                    Category = c.Category,
                    CategoryId = c.CategoryId,
                    Generation = c.Generation,
                    Model = c.Model
                })
                .ToList();
        }

        public IEnumerable<CarInfoServiceModel> AllInfo()
        {
            return this.data.Cars
               .Select(x => new CarInfoServiceModel
               {
                   Id = x.Id,
                   ABS = x.ABS,
                   Model = x.Model,
                   Generation = x.Generation,
                   CategoryId = x.CategoryId,
                   Category = x.Category,
                   Brand = x.Brand,
                   Price = x.Price,
                   Brakes = x.Brakes,
                   BrakesId = x.BrakesId,
                   Color = x.Color,
                   Doors = x.Doors,
                   EmissionStandard = x.EmissionStandard,
                   Engine = x.Engine,
                   EngineId = x.EngineId,
                   FuelConsumption = x.FuelConsumption,
                   Height = x.Height,
                   Image = x.Image,
                   ImageId = x.ImageId,
                   Length = x.Length,
                   MaxWeight = x.MaxWeight,
                   Seats = x.Seats,
                   Suspension = x.Suspension,
                   SuspensionId = x.SuspensionId,
                   Weight = x.Weight,
                   WheelDrive = x.WheelDrive,
                   Wheels = x.Wheels,
                   WheelsId = x.WheelsId,
                   Width = x.Width,
                   YearEnd = x.YearEnd,
                   YearStart = x.YearStart
               });
        }

        public CarInfoServiceModel CarInfo(int id)
        {
            return this.data.Cars
               .Where(x => x.Id == id)
               .Select(x => new CarInfoServiceModel
               {
                   Id = x.Id,
                   ABS = x.ABS,
                   Model = x.Model,
                   Generation = x.Generation,
                   CategoryId = x.CategoryId,
                   Category = x.Category,
                   Brand = x.Brand,
                   Price = x.Price,
                   Brakes = x.Brakes,
                   BrakesId = x.BrakesId,
                   Color = x.Color,
                   Doors = x.Doors,
                   EmissionStandard = x.EmissionStandard,
                   Engine = x.Engine,
                   EngineId = x.EngineId,
                   FuelConsumption = x.FuelConsumption,
                   Height = x.Height,
                   Image = x.Image,
                   ImageId = x.ImageId,
                   Length = x.Length,
                   MaxWeight = x.MaxWeight,
                   Seats = x.Seats,
                   Suspension = x.Suspension,
                   SuspensionId = x.SuspensionId,
                   Weight = x.Weight,
                   WheelDrive = x.WheelDrive,
                   Wheels = x.Wheels,
                   WheelsId = x.WheelsId,
                   Width = x.Width,
                   YearEnd = x.YearEnd,
                   YearStart = x.YearStart
               })
               .FirstOrDefault();
        }

        public bool Exists(int id)
        {
            return this.data.Cars.Any(c => c.Id == id);
        }

        public bool Remove(int id)
        {
            if (!this.Exists(id))
            {
                return false;
            }

            var car = this.data.Cars.FirstOrDefault(x => x.Id == id);
            this.data.Cars.Remove(car);
            this.data.SaveChanges();

            return true;
        }

        public int Total()
        {
            return this.data.Cars.Count();
        }
    }
}
