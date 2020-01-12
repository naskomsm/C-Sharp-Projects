namespace CarsInfo.ConsoleApp
{
    using System.Linq;
    using System.Net;
    using CarsInfo.Data;
    using CarsInfo.Data.Models.Enums.Brakes;
    using CarsInfo.Data.Models.Enums.Car;
    using CarsInfo.Data.Models.Enums.Engine;
    using CarsInfo.Data.Models.Enums.Suspension;
    using CarsInfo.Services.Implementations;
    using CarsInfo.Services.Models.Brakes;
    using CarsInfo.Services.Models.Car;
    using CarsInfo.Services.Models.Category;
    using CarsInfo.Services.Models.Engine;
    using CarsInfo.Services.Models.Image;
    using CarsInfo.Services.Models.Suspension;
    using CarsInfo.Services.Models.User;
    using CarsInfo.Services.Models.Wheels;

    public class Seeder
    {
        private EngineService engineService;
        private ImageService imageService;
        private BrakesService brakesService;
        private CategoryService categoryService;
        private WheelsService wheelsService;
        private UserService userService;
        private CarService carService;
        private SuspensionService suspensionService;
        private CarsInfoDbContext data;

        public Seeder(EngineService engineService, ImageService imageService, BrakesService brakesService,
            CategoryService categoryService, WheelsService wheelsService, UserService userService,
            SuspensionService suspensionService, CarService carService, CarsInfoDbContext data)
        {
            this.engineService = engineService;
            this.imageService = imageService;
            this.brakesService = brakesService;
            this.categoryService = categoryService;
            this.wheelsService = wheelsService;
            this.userService = userService;
            this.suspensionService = suspensionService;
            this.carService = carService;
            this.data = data;
        }

        public void SeedEngines()
        {
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
                Description = "2jz bro its just the best",
                Name = "2JZ",
                ImageId = 4,
                Image = this.data.Images.FirstOrDefault(x => x.Id == 4),
                Price = 150000m,
                FuelInjection = FuelInjection.Direct,
                Turbine = Turbine.Twin,
                CompressionRatio = 10.2,
                NumberOfValvesPerCylinder = 4,
                FuelType = FuelType.Petrol
            };

            engineService.Add(engineModel);
        }

        public void SeedImages()
        {
            WebClient wc = new WebClient();
            var brakesBytes = wc.DownloadData("https://cariteautorepairs.com.au/wp-content/uploads/2014/04/Brakes-700x300.jpg");
            var wheelsBytes = wc.DownloadData("http://osceolaspeedtires.com/wp-content/uploads/2018/11/Rims-page-banner-700x300.jpg");
            var suspensionBytes = wc.DownloadData("http://www.alexlague.com/work/topgear/wp-content/uploads/2016/11/DSC_0646-700x300.jpg");
            var engineBytes = wc.DownloadData("https://www.seawaydeliveries.com/wp-content/uploads/Seaway-Engine-700x300.jpg");
            var carBmwBytes = wc.DownloadData("https://www.carsbmw.net/wp-content/uploads/2016/09/bmw-4-series-gran-coupe-f36-3-700x300.jpg");
            var carSupraBytes = wc.DownloadData("http://osagoinsuranse.ru/wp-content/uploads/2019/11/kasko-700x300.jpg");

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

            // id - 4
            var engineImageModel = new ImageAddServiceModel()
            {
                ImageTitle = "Engine",
                ImageData = engineBytes
            };

            // id - 5
            var carBmwImageModel = new ImageAddServiceModel()
            {
                ImageTitle = "Car - BMW",
                ImageData = carBmwBytes
            };

            // id - 6
            var carSupraImageModel = new ImageAddServiceModel()
            {
                ImageTitle = "Car - Supra",
                ImageData = carSupraBytes
            };

            //string brakesImageBase64Data = Convert.ToBase64String(brakesImageModel.ImageData);
            //string wheelsImageBase64Data = Convert.ToBase64String(wheelsImageModel.ImageData);
            //string suspensionImageBase64Data = Convert.ToBase64String(suspensionImageModel.ImageData);

            imageService.Add(brakesImageModel);
            imageService.Add(wheelsImageModel);
            imageService.Add(suspensionImageModel);
            imageService.Add(engineImageModel);
            imageService.Add(carBmwImageModel);
            imageService.Add(carSupraImageModel);
        }

        public void SeedBrakes()
        {
            var firstBrakesModel = new BrakesAddServiceModel()
            {
                Type = BrakesType.Electromagnetic,
                Description = @"Electromagnetic brakes are likewise often used where an electric motor is already part of the machinery. For example, many hybrid gasoline/electric vehicles use the electric motor as a generator to charge electric batteries and also as a regenerative brake. Some diesel/electric railroad locomotives use the electric motors to generate electricity which is then sent to a resistor bank and dumped as heat. Some vehicles, such as some transit buses, do not already have an electric motor but use a secondary retarder brake that is effectively a generator with an internal short-circuit. Related types of such a brake are eddy current brakes, and electro-mechanical brakes (which actually are magnetically driven friction brakes, but nowadays are often just called electromagnetic brakes as well).",
                Used = false,
                Name = "First Brakes Name",
                Price = 59.99m,
                ImageId = 1,
                Image = this.data.Images.FirstOrDefault(x => x.Id == 1)
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
        }

        public void SeedCategories()
        {
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
        }

        public void SeedSuspensions()
        {
            var suspensionModel = new SuspensionAddServiceModel()
            {
                Type = SuspensionType.Dependent,
                CarBrandMadeFor = "BMW",
                CategoryId = 1,
                Category = data.Categories.FirstOrDefault(x => x.Id == 1),
                ImageId = 3,
                Image = data.Images.FirstOrDefault(x => x.Id == 3),
                Name = "BILSTEIN B8 5100",
                Price = 94.50m
            };

            suspensionService.Add(suspensionModel);
        }

        public void SeedWheels()
        {
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

            wheelsService.Add(wheelsModel);
        }

        public void SeedUsers()
        {
            var userModel = new UserAddServiceModel()
            {
                Email = "naskokolev@gmail.com",
                Password = "Xtw9NMgx"
            };

            userService.Register(userModel);
        }

        public void SeedCars()
        {
            var firstCarModel = new CarAddServiceModel()
            {
                Brand = "Toyota",
                Model = "Supra",
                Price = 60000m,
                Generation = "4th",
                Color = "Blue",
                YearStart = 1978,
                YearEnd = 2002,
                Seats = 5,
                Doors = 4,
                Length = 4.5,
                Width = 2.2,
                Height = 1.8,
                FuelConsumption = 15,
                Weight = 2200,
                MaxWeight = 5000,
                EmissionStandard = EmissionStandard.Four,
                CategoryId = 1,
                Category = this.data.Categories.FirstOrDefault(x => x.Id == 1),
                EngineId = 1,
                Engine = this.data.Engines.FirstOrDefault(x => x.Id == 1),
                ImageId = 6,
                Image = this.data.Images.FirstOrDefault(x => x.Id == 6),
                ABS = true,
                WheelDrive = WheelDrive.Rear,
                WheelsId = 1,
                Wheels = this.data.Wheels.FirstOrDefault(x => x.Id == 1),
                SuspensionId = 1,
                Suspension = this.data.Suspensions.FirstOrDefault(x => x.Id == 1),
                BrakesId = 1,
                Brakes = this.data.Brakes.FirstOrDefault(x => x.Id == 1)
            };
            
            var secondCarModel = new CarAddServiceModel()
            {
                Brand = "BMW",
                Model = "M5",
                Generation = "F10",
                Color = "Blue",
                Price = 150000m,
                YearStart = 2012,
                Seats = 5,
                Doors = 4,
                Length = 4.5,
                Width = 2.2,
                Height = 1.8,
                FuelConsumption = 15,
                Weight = 2200,
                MaxWeight = 5000,
                EmissionStandard = EmissionStandard.Four,
                CategoryId = 1,
                Category = this.data.Categories.FirstOrDefault(x => x.Id == 1),
                EngineId = 1,
                Engine = this.data.Engines.FirstOrDefault(x => x.Id == 1),
                ImageId = 5,
                Image = this.data.Images.FirstOrDefault(x => x.Id == 5),
                ABS = true,
                WheelDrive = WheelDrive.Rear,
                WheelsId = 1,
                Wheels = this.data.Wheels.FirstOrDefault(x => x.Id == 1),
                SuspensionId = 1,
                Suspension = this.data.Suspensions.FirstOrDefault(x => x.Id == 1),
                BrakesId = 1,
                Brakes = this.data.Brakes.FirstOrDefault(x => x.Id == 1)
            };

            this.carService.Add(firstCarModel);
            this.carService.Add(secondCarModel);
        }
    }
}
