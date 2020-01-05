namespace CarsInfo.ConsoleApp
{
    using CarsInfo.Data;
    using Microsoft.EntityFrameworkCore;

    public class Program
    {
        public static void Main()
        {
            using var data = new CarsInfoDbContext();
            data.Database.Migrate();

            // Engine
            //var engineService = new EngineService(data);
            //var engineModel = new EngineAddServiceModel()
            //{
            //    Position = Position.Front,
            //    CylindersDiameter = 84.0,
            //    CylindersStroke = 89.6,
            //    CylindersCount = 4,
            //    CylindersPosition = CylindersPosition.Inline,
            //    Volume = 2979,
            //    MaxPowerIn = 5500,
            //    Torque = 550,
            //    FuelInjection = FuelInjection.Direct,
            //    Turbine = Turbine.Twin,
            //    CompressionRatio = 10.2,
            //    NumberOfValvesPerCylinder = 4,
            //    FuelType = FuelType.Petrol
            //};

            //engineService.Add(engineModel);

            // Brakes
            //var brakesService = new BrakesService(data);
            //var brakesModel = new BrakesAddServiceModel()
            //{
            //    Type = BrakesType.Electromagnetic,
            //    Used = false
            //};

            //brakesService.Add(brakesModel);
        }
    }
}
