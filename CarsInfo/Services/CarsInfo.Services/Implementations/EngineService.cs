namespace CarsInfo.Services.Implementations
{
    using CarsInfo.Data;
    using CarsInfo.Data.Models;
    using CarsInfo.Data.Models.Enums.Engine;
    using CarsInfo.Services.Models.Engine;
    using System;
    using System.Linq;

    public class EngineService : IEngineService
    {
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
                CompressionRatio = model.CompressionRatio,
                NumberOfValvesPerCylinder = model.NumberOfValvesPerCylinder,
                FuelType = model.FuelType
            };

            this.data.Engines.Add(engine);
            this.data.SaveChanges();
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

            return true;
        }
    }
}
