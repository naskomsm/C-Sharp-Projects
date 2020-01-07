namespace CarsInfo.ConsoleApp
{
    using System;
    using System.Net;
    using System.Linq;
    using CarsInfo.Data;
    using CarsInfo.Data.Models.Enums.Brakes;
    using CarsInfo.Data.Models.Enums.Engine;
    using CarsInfo.Data.Models.Enums.Suspension;
    using CarsInfo.Services.Implementations;
    using CarsInfo.Services.Models.Brakes;
    using CarsInfo.Services.Models.Category;
    using CarsInfo.Services.Models.Engine;
    using CarsInfo.Services.Models.Image;
    using CarsInfo.Services.Models.Suspension;
    using CarsInfo.Services.Models.User;
    using CarsInfo.Services.Models.Wheels;
    using Microsoft.EntityFrameworkCore;

    public class Program
    {
        public static void Main()
        {
            using var data = new CarsInfoDbContext();
            data.Database.Migrate();

            // Engine
            var engineService = new EngineService(data);
            var engineModel = new EngineAddServiceModel()
            {
                Position = Position.Front,
                CylindersDiameter = 84.0,
                CylindersStroke = 89.6,
                CylindersCount = 4,
                CylindersPosition = CylindersPosition.Inline,
                Volume = 2979,
                MaxPowerIn = 5500,
                Torque = 550,
                FuelInjection = FuelInjection.Direct,
                Turbine = Turbine.Twin,
                CompressionRatio = 10.2,
                NumberOfValvesPerCylinder = 4,
                FuelType = FuelType.Petrol
            };

            engineService.Add(engineModel);

            // Brakes
            var brakesService = new BrakesService(data);
            var brakesModel = new BrakesAddServiceModel()
            {
                Type = BrakesType.Electromagnetic,
                Used = false
            };

            brakesService.Add(brakesModel);

            // Category
            var categoryService = new CategoryService(data);

            var firstCategoryModel = new CategoryAddServiceModel()
            {
                Name = "Sedan",
                Description = "Family car, 4-doors, pretty much the best."
            };

            var secondCategoryModel = new CategoryAddServiceModel()
            {
                Name = "Coupe"
            };

            categoryService.Add(firstCategoryModel);
            categoryService.Add(secondCategoryModel);

            // Image
            var imageService = new ImageService(data);

            WebClient wc = new WebClient();
            byte[] bytes = wc.DownloadData("https://images.theconversation.com/files/301743/original/file-20191114-26207-lray93.jpg?ixlib=rb-1.1.0&q=45&auto=format&w=926&fit=clip");

            var imageModel = new ImageAddServiceModel()
            {
                ImageTitle = "Cat",
                ImageData = bytes
            };

            string imageBase64Data = Convert.ToBase64String(imageModel.ImageData);

            imageService.Add(imageModel);

            // suspension
            var suspensionService = new SuspensionService(data);

            var category = data.Categories.FirstOrDefault(x => x.Id == 1);
            var image = data.Images.FirstOrDefault(x => x.Id == 1);

            var suspensionModel = new SuspensionAddServiceModel()
            {
                Type = SuspensionType.Dependent,
                CarBrandMadeFor = "BMW",
                CategoryId = category.Id,
                Category = category,
                ImageId = image.Id,
                Image = image
            };

            suspensionService.Add(suspensionModel);

            var wheelService = new WheelsService(data);

            var wheelsModel = new WheelsAddServiceModel()
            {
                Name = "OZ Leggera HLT Gloss Black",
                Used = false,
                Weight = 11,
                Color = "Gloss Black",
                FrontAxleSize = "9.0 x 19 - ET 20.0",
                RearAxleSize = "10.0 x 19 - ET 32.0",
                ImageId = image.Id,
                Image = image
            };

            wheelService.Add(wheelsModel);

            var userService = new UserService(data);

            var userModel = new UserAddServiceModel()
            {
                Email = "naskokolev@gmail.com",
                Password = "Xtw9NMgx"
            };

            userService.Register(userModel);
        }
    }
}
