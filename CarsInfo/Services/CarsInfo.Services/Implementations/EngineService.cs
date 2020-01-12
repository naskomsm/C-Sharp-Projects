namespace CarsInfo.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CarsInfo.Data;
    using CarsInfo.Data.Models;
    using CarsInfo.Data.Models.Enums.Engine;
    using CarsInfo.Services.Models.Engine;

    public class EngineService : IEngineService
    {
        private const int pageSize = 6;

        private readonly CarsInfoDbContext data;

        public EngineService(CarsInfoDbContext data)
        {
            this.data = data;
        }

        public void Add(EngineAddServiceModel model)
        {
            var isPositionValid = Enum.IsDefined(typeof(Position), model.Position);
            var isCylindersPositionValid = Enum.IsDefined(typeof(CylindersPosition), model.CylindersPosition);
            var isFuelInjectionValid = Enum.IsDefined(typeof(FuelInjection), model.FuelInjection);
            var isTurbineValid = Enum.IsDefined(typeof(Turbine), model.Turbine);
            var isFuelTypeValid = Enum.IsDefined(typeof(FuelType), model.FuelType);

            if(!isPositionValid || !isCylindersPositionValid || !isFuelInjectionValid || !isTurbineValid || !isFuelTypeValid)
            {
                throw new ArgumentException("Cannot attach invalid enum to object.");
            }

            if (!DataValidation.IsValid(model))
            {
                throw new ArgumentException("Invalid data.");
            }

            var engine = new Engine()
            {
                Position = model.Position,
                CylindersDiameter = model.CylindersDiameter,
                CylindersStroke = model.CylindersStroke,
                CylindersCount = model.CylindersCount,
                CylindersPosition = model.CylindersPosition,
                Volume = model.Volume,
                MaxPowerIn = model.MaxPowerIn,
                Torque = model.Torque,
                FuelInjection = model.FuelInjection,
                Turbine = model.Turbine,
                Description = model.Description,
                Price = model.Price,
                Image = model.Image,
                ImageId = model.ImageId,
                Name = model.Name,
                CompressionRatio = model.CompressionRatio,
                NumberOfValvesPerCylinder = model.NumberOfValvesPerCylinder,
                FuelType = model.FuelType
            };

            this.data.Engines.Add(engine);
            this.data.SaveChanges();
        }

        public IEnumerable<EngineListingServiceModel> All(int page = 1)
        {
            return this.data
                .Engines
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(e => new EngineListingServiceModel
                {
                    Id = e.Id,
                    CylindersCount = e.CylindersCount,
                    Name = e.Name,
                    Price = e.Price,
                    ImageId = e.ImageId,
                    Image = e.Image
                })
                .ToList();
        }

        public IEnumerable<EngineInfoServiceModel> AllInfo()
        {
            return this.data.Engines
               .Select(e => new EngineInfoServiceModel
               {
                   Id = e.Id,
                   CylindersCount = e.CylindersCount,
                   Name = e.Name,
                   Price = e.Price,
                   ImageId = e.ImageId,
                   Image = e.Image,
                   CompressionRatio = e.CompressionRatio,
                   CylindersDiameter = e.CylindersDiameter,
                   CylindersPosition = e.CylindersPosition.ToString(),
                   CylindersStroke = e.CylindersStroke,
                   Description = e.Description,
                   FuelInjection = e.FuelInjection.ToString(),
                   FuelType = e.FuelType.ToString(),
                   MaxPowerIn = e.MaxPowerIn,
                   NumberOfValvesPerCylinder = e.NumberOfValvesPerCylinder,
                   Position = e.Position.ToString(),
                   Torque = e.Torque,
                   Turbine = e.Turbine.ToString(),
                   Volume = e.Volume
               }) ;
        }

        public EngineInfoServiceModel EngineInfo(int id)
        {
            return this.data.Engines
                .Where(e => e.Id == id)
                .Select(e => new EngineInfoServiceModel
                {
                    Id = e.Id,
                    CylindersCount = e.CylindersCount,
                    Name = e.Name,
                    Price = e.Price,
                    ImageId = e.ImageId,
                    Image = e.Image,
                    CompressionRatio = e.CompressionRatio,
                    CylindersDiameter = e.CylindersDiameter,
                    CylindersPosition = e.CylindersPosition.ToString(),
                    CylindersStroke = e.CylindersStroke,
                    Description = e.Description,
                    FuelInjection = e.FuelInjection.ToString(),
                    FuelType = e.FuelType.ToString(),
                    MaxPowerIn = e.MaxPowerIn,
                    NumberOfValvesPerCylinder = e.NumberOfValvesPerCylinder,
                    Position = e.Position.ToString(),
                    Torque = e.Torque,
                    Turbine = e.Turbine.ToString(),
                    Volume = e.Volume
                })
                .FirstOrDefault();
        }

        public bool Exists(int id)
        {
            return this.data.Engines.Any(e => e.Id == id);
        }

        public bool Remove(int id)
        {
            if (!this.Exists(id))
            {
                return false;
            }

            var engine = this.data.Engines.FirstOrDefault(x => x.Id == id);
            this.data.Engines.Remove(engine);
            this.data.SaveChanges();

            return true;
        }

        public int Total()
        {
            return this.data.Engines.Count();
        }
    }
}
