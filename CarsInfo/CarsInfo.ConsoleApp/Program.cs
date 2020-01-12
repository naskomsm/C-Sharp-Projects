namespace CarsInfo.ConsoleApp
{
    using CarsInfo.Data;
    using Microsoft.EntityFrameworkCore;
    using CarsInfo.Services.Implementations;

    public class Program
    {
        public static void Main()
        {
            using var data = new CarsInfoDbContext();
            data.Database.Migrate();

            var engineService = new EngineService(data);
            var imageService = new ImageService(data);
            var brakesService = new BrakesService(data);
            var categoryService = new CategoryService(data);
            var suspensionService = new SuspensionService(data);
            var wheelsService = new WheelsService(data);
            var carService = new CarService(data);
            var userService = new UserService(data);

            var seeder = new Seeder(engineService, imageService, brakesService, categoryService,
                wheelsService, userService, suspensionService, carService, data);

            seeder.SeedImages();
            seeder.SeedEngines();
            seeder.SeedBrakes();
            seeder.SeedCategories();
            seeder.SeedWheels();
            seeder.SeedSuspensions();
            seeder.SeedUsers();
            seeder.SeedCars();
        }
    }
}
