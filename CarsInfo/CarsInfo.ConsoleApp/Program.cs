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

            // Image
            var imageService = new ImageService(data);

            WebClient wc = new WebClient();
            var brakesBytes = wc.DownloadData("https://cariteautorepairs.com.au/wp-content/up                                                                                                                                                                                                                                                                                     loads/2014/04/Brakes-700x300.jpg");
            var wheelsBytes = wc.DownloadData("http://osceolaspeedtires.com/wp-content/uploads/2018/11/Rims-page-banner-700x300.jpg");
            var suspensionBytes = wc.DownloadData("http://www.alexlague.com/work/topgear/wp-content/uploads/2016/11/DSC_0646-700x300.jpg");

            // id - 1  
            var brakesImageModel = new ImageAddServiceModel()
            {
                ImageTitle = "Brakes",
                ImageData = brakesBytes
            };

            // id - 2
            var wheelsImageModel = new ImageAddServiceModel()
            {
                ImageTitle = "Wheels",
                ImageData = wheelsBytes
            };

            // id - 3
            var suspensionImageModel = new ImageAddServiceModel()
            {
                ImageTitle = "Suspension",
                ImageData = suspensionBytes
            };

            string brakesImageBase64Data = Convert.ToBase64String(brakesImageModel.ImageData);
            string wheelsImageBase64Data = Convert.ToBase64String(wheelsImageModel.ImageData);
            string suspensionImageBase64Data = Convert.ToBase64String(suspensionImageModel.ImageData);

            imageService.Add(brakesImageModel);
            imageService.Add(wheelsImageModel);
            imageService.Add(suspensionImageModel);

            //Brakes
            var brakesService = new BrakesService(data);
            var firstBrakesModel = new BrakesAddServiceModel()
            {
                Type = BrakesType.Electromagnetic,
                Description = @"Electromagnetic brakes are likewise often used where an electric motor is already part of the machinery. For example, many hybrid gasoline/electric vehicles use the electric motor as a generator to charge electric batteries and also as a regenerative brake. Some diesel/electric railroad locomotives use the electric motors to generate electricity which is then sent to a resistor bank and dumped as heat. Some vehicles, such as some transit buses, do not already have an electric motor but use a secondary retarder brake that is effectively a generator with an internal short-circuit. Related types of such a brake are eddy current brakes, and electro-mechanical brakes (which actually are magnetically driven friction brakes, but nowadays are often just called electromagnetic brakes as well).",
                Used = false,
                Name = "First Brakes Name",
                Price = 59.99m,
                ImageId = 1,
                Image = data.Images.FirstOrDefault(x => x.Id == 1)
            };

            var secondBrakesModel = new BrakesAddServiceModel()
            {
                Type = BrakesType.Pumping,
                Description = @"randomn brakes blblabllablalallal description",
                Used = false,
                Name = "Secpmd Brakes Name",
                Price = 79.99m,
            };

            brakesService.Add(firstBrakesModel);
            brakesService.Add(secondBrakesModel);

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

            // suspension
            var suspensionService = new SuspensionService(data);

            var category = data.Categories.FirstOrDefault(x => x.Id == 1);

            var suspensionModel = new SuspensionAddServiceModel()
            {
                Type = SuspensionType.Dependent,
                CarBrandMadeFor = "BMW",
                CategoryId = category.Id,
                Category = category,
                ImageId = 3,
                Image = data.Images.FirstOrDefault(x => x.Id == 3),
                Name = "BILSTEIN B8 5100",
                Price = 94.50m
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
                ImageId = 2,
                Image = data.Images.FirstOrDefault(x => x.Id == 2),
                Description = "just random wheels description",
                Price = 990m
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
