namespace PetStore
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Services.Implementations;

    public class Program
    {
        public static void Main()
        {
            using var data = new PetStoreDbContext();
            
            data.Database.Migrate();

            // Services
            var brandService = new BrandService(data);
            var breedService = new BreedService(data);
            var categoryService = new CategoryService(data);
            var userService = new UserService(data);
            var foodService = new FoodService(data, userService);
            var petService = new PetService(data, categoryService, breedService, userService);
            var toyService = new ToyService(data, userService);

            //brandService.Create("Whiskas");
            //brandService.Create("9Lives");
            //brandService.Create("Friskies");
            //brandService.Create("Halo");

            //breedService.Add("Abyssian");
            //breedService.Add("Birman");
            //breedService.Add("Bengal");
            //breedService.Add("Chartreux");

            //categoryService.Add("Cat", "A cat is some cute animal");
            //categoryService.Add("Dog", "The dog is another cute animal");
            //categoryService.Add("Whale");
            //categoryService.Add("Parrot");

            //foodService.BuyFromDistributor("Meaty Bits", 156, 2, 3.50m,
            //    DateTime.Now.AddDays(30),
            //    brandService.GetIdByName("Friskies"),
            //    categoryService.GetIdByName("Cat"));

            //foodService.BuyFromDistributor("Meaty Nuggets", 400, 3, 5.75m,
            //    DateTime.Now.AddDays(60),
            //    brandService.GetIdByName("Whiskas"),
            //    categoryService.GetIdByName("Cat"));

            //foodService.BuyFromDistributor("Hearty Cuts", 168, 3, 1.75m,
            //   DateTime.Now.AddDays(42),
            //   brandService.GetIdByName("9Lives"),
            //   categoryService.GetIdByName("Cat"));

            //foodService.BuyFromDistributor("Holistic Chicken", 149, 2, 2.75m,
            //  DateTime.Now.AddDays(15),
            //  brandService.GetIdByName("Halo"),
            //  categoryService.GetIdByName("Cat"));

            //userService.Register("Atanas Kolev", "naskokolev00@gmail.com");
            //userService.Register("Daniel Ivanov", "danielivanov99@gmail.com");
            //userService.Register("Georgi Petrov", "georgipetrov00@gmail.com");
            //userService.Register("Ivan Panagonov", "ivanpanagonov00@gmail.com");

            //foodService.SellFoodToUser(foodService.GetIdByName("Meaty Bits"), 
            //    userService.GetIdByName("Atanas Kolev"));

            //foodService.SellFoodToUser(foodService.GetIdByName("Meaty Nuggets"),
            //    userService.GetIdByName("Daniel Ivanov"));

            //foodService.SellFoodToUser(foodService.GetIdByName("Hearty Cuts"),
            //    userService.GetIdByName("Georgi Petrov"));

            //foodService.SellFoodToUser(foodService.GetIdByName("Holistic Chicken"),
            //    userService.GetIdByName("Ivan Panagonov"));

            //petService.BuyPet(Gender.Male, DateTime.Now.AddDays(-90), 350, "",
            //    breedService.GetIdByName("Abyssian"), categoryService.GetIdByName("Cat"));

            //petService.BuyPet(Gender.Female, DateTime.Now.AddDays(-476), 400, "Female cat...",
            //    breedService.GetIdByName("Birman"), categoryService.GetIdByName("Cat"));

            //petService.BuyPet(Gender.Female, DateTime.Now.AddDays(-90), 350, "Another female cat",
            //    breedService.GetIdByName("Bengal"), categoryService.GetIdByName("Cat"));

            //petService.BuyPet(Gender.Male, DateTime.Now.AddDays(-841), 982, "",
            //    breedService.GetIdByName("Chartreux"), categoryService.GetIdByName("Cat"));

            //toyService.BuyFromDistributor("Truck", "", 3.50m, 2,
            //    brandService.GetIdByName("Whiskas"),
            //    categoryService.GetIdByName("Cat"));

            //toyService.BuyFromDistributor("Car", "", 2.50m, 4,
            //    brandService.GetIdByName("9Lives"),
            //    categoryService.GetIdByName("Cat"));

            //toyService.BuyFromDistributor("Bear", "", 5.50m, 3,
            //   brandService.GetIdByName("Friskies"),
            //   categoryService.GetIdByName("Cat"));

            //toyService.BuyFromDistributor("Ball", "", 3.50m, 4,
            //   brandService.GetIdByName("Halo"),
            //   categoryService.GetIdByName("Cat"));

            //toyService.SellToyToUser(toyService.GetIdByName("Truck"), userService.GetIdByName("Atanas Kolev"));
            //toyService.SellToyToUser(toyService.GetIdByName("Car"), userService.GetIdByName("Atanas Kolev"));
            //toyService.SellToyToUser(toyService.GetIdByName("Bear"), userService.GetIdByName("Daniel Ivanov"));
            //toyService.SellToyToUser(toyService.GetIdByName("Ball"), userService.GetIdByName("Georgi Petrov"));
        }
    }
}
