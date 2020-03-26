namespace Sabv.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using Sabv.Data.Models;
    using Sabv.Data.Models.Enums;
    using Sabv.Services.Data;

    public class PostsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Posts.Any())
            {
                return;
            }

            var postsService = serviceProvider.GetRequiredService<IPostsService>();
            var categoriesService = serviceProvider.GetRequiredService<ICategoriesService>();
            var vehicleCategoriesService = serviceProvider.GetRequiredService<IVehicleCategoriesService>();
            var colorsService = serviceProvider.GetRequiredService<IColorService>();
            var makesService = serviceProvider.GetRequiredService<IMakesService>();
            var modelsService = serviceProvider.GetRequiredService<IModelsService>();
            var citiesService = serviceProvider.GetRequiredService<ICitiesService>();
            var imagesService = serviceProvider.GetRequiredService<IImagesService>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var allImages = imagesService.GetAll().Skip(4).ToList();
            var user = await userManager.FindByNameAsync("GOD");

            // Cars
            var bmwM5e60 = new Post()
            {
                Name = makesService.GetMakeByName("BMW").Name + " " + modelsService.GetModelByName("M5").Name + " E60",
                Category = categoriesService.GetCategoryByName("Cars and jeeps"),
                CategoryId = categoriesService.GetCategoryByName("Cars and jeeps").Id,
                City = citiesService.GetCityByName("Stara Zagora"),
                CityId = citiesService.GetCityByName("Stara Zagora").Id,
                Make = makesService.GetMakeByName("BMW"),
                MakeId = makesService.GetMakeByName("BMW").Id,
                Model = modelsService.GetModelByName("M5"),
                ModelId = modelsService.GetModelByName("M5").Id,
                Color = colorsService.GetColorByName("Light Blue"),
                ColorId = colorsService.GetColorByName("Light Blue").Id,
                Horsepower = 507,
                Eurostandard = Eurostandard.Four,
                Description = @"The BMW M5 is a high performance variant of the BMW 5 Series marketed under the BMW M sub-brand. It is considered an iconic vehicle in the sports sedan category.The majority of M5's have been produced in the sedan (saloon) body style, but in some countries the M5 was also available as a wagon (estate) from 1992–1995 and 2006–2010.The first M5 model was hand-built in 1985 on the E28 535i chassis with a modified engine from the M1 that made it the fastest production sedan at the time.[5] M5 models have been produced for every generation of the 5 Series since 1985.",
                Mileage = 56123,
                User = user,
                UserId = user.Id,
                VehicleCategory = vehicleCategoriesService.GetVehicleCategoryByName("Sedan"),
                VehicleCategoryId = vehicleCategoriesService.GetVehicleCategoryByName("Sedan").Id,
                EngineType = EngineType.Petrol,
                Currency = Currency.LV,
                Condition = Condition.Used,
                PhoneNumber = "0845614578",
                ManufactureDate = new DateTime(2005, 4, 2),
                TransmissionType = TransmissionType.Automatic,
                Price = 63500,
                Email = user.Email,
            };
            var audiRS7 = new Post()
            {
                Name = makesService.GetMakeByName("Audi").Name + " " + modelsService.GetModelByName("RS7").Name,
                Category = categoriesService.GetCategoryByName("Cars and jeeps"),
                CategoryId = categoriesService.GetCategoryByName("Cars and jeeps").Id,
                City = citiesService.GetCityByName("Sofia"),
                CityId = citiesService.GetCityByName("Sofia").Id,
                Make = makesService.GetMakeByName("Audi"),
                MakeId = makesService.GetMakeByName("Audi").Id,
                Model = modelsService.GetModelByName("RS7"),
                ModelId = modelsService.GetModelByName("RS7").Id,
                Color = colorsService.GetColorByName("Grey"),
                ColorId = colorsService.GetColorByName("Grey").Id,
                Horsepower = 560,
                Eurostandard = Eurostandard.Five,
                Description = @"The Audi RS7 has 1 Petrol Engine on offer. The Petrol engine is 3993 cc. It is available with the transmission. Depending upon the variant and fuel type the RS7 has a mileage of 13.9 kmpl. The RS7 is a 4 seater Sedan and has a length of 5012mm, width of 1911mm and a wheelbase of 2915mm.",
                Mileage = 61222,
                User = user,
                UserId = user.Id,
                VehicleCategory = vehicleCategoriesService.GetVehicleCategoryByName("Sedan"),
                VehicleCategoryId = vehicleCategoriesService.GetVehicleCategoryByName("Sedan").Id,
                EngineType = EngineType.Petrol,
                Currency = Currency.LV,
                Condition = Condition.Used,
                PhoneNumber = "0895764813",
                ManufactureDate = new DateTime(2012, 4, 2),
                TransmissionType = TransmissionType.Automatic,
                Price = 93000,
                Email = user.Email,
            };
            var mercedesS600 = new Post()
            {
                Name = makesService.GetMakeByName("Mercedes-Benz").Name + " " + modelsService.GetModelByName("S 600").Name + " W222",
                Category = categoriesService.GetCategoryByName("Cars and jeeps"),
                CategoryId = categoriesService.GetCategoryByName("Cars and jeeps").Id,
                City = citiesService.GetCityByName("Sofia"),
                CityId = citiesService.GetCityByName("Sofia").Id,
                Make = makesService.GetMakeByName("Mercedes-Benz"),
                MakeId = makesService.GetMakeByName("Mercedes-Benz").Id,
                Model = modelsService.GetModelByName("S 600"),
                ModelId = modelsService.GetModelByName("S 600").Id,
                Color = colorsService.GetColorByName("Grey"),
                ColorId = colorsService.GetColorByName("Grey").Id,
                Horsepower = 608,
                Eurostandard = Eurostandard.Five,
                Description = @"The Mercedes-Benz S-Class, formerly known as Sonderklasse (German for special class, abbreviated as S-Klasse), is a series of full-size luxury sedans and limousines produced by the German automaker Mercedes-Benz, a division of German company Daimler AG. The S-Class designation for top-of-the-line Mercedes-Benz models was officially introduced in 1972 with the W116, and has remained in use ever since. The S-Class has debuted many of the company's latest innovations, including drivetrain technologies, interior features, and safety systems (such as the first seatbelt pretensioners). The S-Class has ranked as the world's best-selling luxury sedan, and its latest generation, the W222 S-Class, premiered in 2013. As in previous iterations, the W222 S-Class is sold in standard and long-wheelbase versions; I4, V6, V8, V12, diesel and hybrid powertrains are offered. All models sold in North America are available in long wheelbase only. In automotive terms, Sonderklasse refers to a specially outfitted car. Although used colloquially for decades,[citation needed] following its official application in 1972, six generations of officially named S-Klasse sedans have been produced. Previous two-door coupe models of the S-Class were known as SEC and later S-Coupe. In 1996 the S-Class coupe was spun off in a separate line as the CL-Class, however as of June 2014, it has been re-designated as the S-Class Coupé for the 2015 model year, doing away with the CL-Class. In 2016, the S-Class Cabriolet, internally named A217, was introduced with three variants: the S 550 Cabriolet, the Mercedes-AMG S 63 Cabriolet with 4Matic, and the Mercedes-AMG S 65 Cabriolet. The Mercedes-Maybach S 650 Cabriolet, based on the S 65 Cabriolet, was announced in 2016.",
                Mileage = 48666,
                User = user,
                UserId = user.Id,
                VehicleCategory = vehicleCategoriesService.GetVehicleCategoryByName("Stretch limousine"),
                VehicleCategoryId = vehicleCategoriesService.GetVehicleCategoryByName("Stretch limousine").Id,
                EngineType = EngineType.Petrol,
                Currency = Currency.LV,
                Condition = Condition.Used,
                PhoneNumber = "0896321478",
                ManufactureDate = new DateTime(2014, 4, 2),
                TransmissionType = TransmissionType.Automatic,
                Price = 125478,
                Email = user.Email,
            };
            var bmwM3f80 = new Post()
            {
                Name = makesService.GetMakeByName("BMW").Name + " " + modelsService.GetModelByName("M3").Name + " F80",
                Category = categoriesService.GetCategoryByName("Cars and jeeps"),
                CategoryId = categoriesService.GetCategoryByName("Cars and jeeps").Id,
                City = citiesService.GetCityByName("Stara Zagora"),
                CityId = citiesService.GetCityByName("Stara Zagora").Id,
                Make = makesService.GetMakeByName("BMW"),
                MakeId = makesService.GetMakeByName("BMW").Id,
                Model = modelsService.GetModelByName("M3"),
                ModelId = modelsService.GetModelByName("M3").Id,
                Color = colorsService.GetColorByName("Blue"),
                ColorId = colorsService.GetColorByName("Blue").Id,
                Horsepower = 431,
                Eurostandard = Eurostandard.Six,
                Description = @"The BMW M3 is a high-performance version of the BMW 3 Series, developed by BMW's in-house motorsport division, BMW M GmbH. M3 models have been produced for every generation of 3 Series since the E30 M3 was introduced in 1986.The initial model was available in a coupé body style, with a convertible body style added soon after. M3 sedans were available during the E36 (1994–1999) and E90 (2008–2012) generations. Since 2015 the M3 has been solely produced in the sedan body style, due to the coupé and convertible models being rebranded as the 4 Series range, making the high-performance variant the M4.Upgrades over the regular 3 Series models include engines, handling, brakes, aerodynamics, lightweight materials and various interior upgrades.",
                Mileage = 21456,
                User = user,
                UserId = user.Id,
                VehicleCategory = vehicleCategoriesService.GetVehicleCategoryByName("Sedan"),
                VehicleCategoryId = vehicleCategoriesService.GetVehicleCategoryByName("Sedan").Id,
                EngineType = EngineType.Petrol,
                Currency = Currency.LV,
                Condition = Condition.Used,
                PhoneNumber = "0898741236",
                ManufactureDate = new DateTime(2018, 4, 2),
                TransmissionType = TransmissionType.Automatic,
                Price = 87514,
                Email = user.Email,
            };
            var bmwM5f10 = new Post()
            {
                Name = makesService.GetMakeByName("BMW").Name + " " + modelsService.GetModelByName("M5").Name + " F10",
                Category = categoriesService.GetCategoryByName("Cars and jeeps"),
                CategoryId = categoriesService.GetCategoryByName("Cars and jeeps").Id,
                City = citiesService.GetCityByName("Stara Zagora"),
                CityId = citiesService.GetCityByName("Stara Zagora").Id,
                Make = makesService.GetMakeByName("BMW"),
                MakeId = makesService.GetMakeByName("BMW").Id,
                Model = modelsService.GetModelByName("M5"),
                ModelId = modelsService.GetModelByName("M5").Id,
                Color = colorsService.GetColorByName("Blue"),
                ColorId = colorsService.GetColorByName("Blue").Id,
                Horsepower = 560,
                Eurostandard = Eurostandard.Five,
                Description = @"The BMW M5 is a high performance variant of the BMW 5 Series marketed under the BMW M sub-brand. It is considered an iconic vehicle in the sports sedan category.The majority of M5's have been produced in the sedan (saloon) body style, but in some countries the M5 was also available as a wagon (estate) from 1992–1995 and 2006–2010.The first M5 model was hand-built in 1985 on the E28 535i chassis with a modified engine from the M1 that made it the fastest production sedan at the time.[5] M5 models have been produced for every generation of the 5 Series since 1985.",
                Mileage = 145321,
                User = user,
                UserId = user.Id,
                VehicleCategory = vehicleCategoriesService.GetVehicleCategoryByName("Sedan"),
                VehicleCategoryId = vehicleCategoriesService.GetVehicleCategoryByName("Sedan").Id,
                EngineType = EngineType.Petrol,
                Currency = Currency.LV,
                Condition = Condition.Used,
                PhoneNumber = "0845614578",
                ManufactureDate = new DateTime(2012, 4, 2),
                TransmissionType = TransmissionType.Automatic,
                Price = 84000,
                Email = user.Email,
            };
            var audiRS6 = new Post()
            {
                Name = makesService.GetMakeByName("Audi").Name + " " + modelsService.GetModelByName("RS6").Name + " C7",
                Category = categoriesService.GetCategoryByName("Cars and jeeps"),
                CategoryId = categoriesService.GetCategoryByName("Cars and jeeps").Id,
                City = citiesService.GetCityByName("Sofia"),
                CityId = citiesService.GetCityByName("Sofia").Id,
                Make = makesService.GetMakeByName("Audi"),
                MakeId = makesService.GetMakeByName("Audi").Id,
                Model = modelsService.GetModelByName("RS6"),
                ModelId = modelsService.GetModelByName("RS6").Id,
                Color = colorsService.GetColorByName("Red"),
                ColorId = colorsService.GetColorByName("Red").Id,
                Horsepower = 560,
                Eurostandard = Eurostandard.Five,
                Description = @"The Audi RS 6 is a high-performance variant of the Audi A6 range, produced by the high-performance subsidiary company Audi Sport GmbH, for Audi AG, a division of the Volkswagen Group.The first and second versions of the RS 6 were offered in both Avant and saloon forms. The third generation is only offered as an Avant.",
                Mileage = 144562,
                User = user,
                UserId = user.Id,
                VehicleCategory = vehicleCategoriesService.GetVehicleCategoryByName("Combi"),
                VehicleCategoryId = vehicleCategoriesService.GetVehicleCategoryByName("Combi").Id,
                EngineType = EngineType.Petrol,
                Currency = Currency.LV,
                Condition = Condition.Used,
                PhoneNumber = "0895764813",
                ManufactureDate = new DateTime(2014, 4, 2),
                TransmissionType = TransmissionType.Automatic,
                Price = 93000,
                Email = user.Email,
            };
            var mercedesGClass = new Post()
            {
                Name = makesService.GetMakeByName("Mercedes-Benz").Name + " " + modelsService.GetModelByName("G 500").Name,
                Category = categoriesService.GetCategoryByName("Cars and jeeps"),
                CategoryId = categoriesService.GetCategoryByName("Cars and jeeps").Id,
                City = citiesService.GetCityByName("Sofia"),
                CityId = citiesService.GetCityByName("Sofia").Id,
                Make = makesService.GetMakeByName("Mercedes-Benz"),
                MakeId = makesService.GetMakeByName("Mercedes-Benz").Id,
                Model = modelsService.GetModelByName("G 500"),
                ModelId = modelsService.GetModelByName("G 500").Id,
                Color = colorsService.GetColorByName("Brown"),
                ColorId = colorsService.GetColorByName("Brown").Id,
                Horsepower = 422,
                Eurostandard = Eurostandard.Five,
                Description = @"The Mercedes-Benz G-Class, sometimes called G-Wagen (short for Geländewagen, terrain vehicle), is a mid-size four-wheel drive luxury SUV manufactured by Magna Steyr (formerly Steyr-Daimler-Puch) in Austria and sold by Mercedes-Benz. In certain markets, it has been sold under the Puch name as Puch G.The G-Wagen is characterised by its boxy styling and body-on-frame construction. It uses three fully locking differentials, one of the few vehicles to have such a feature.Despite the introduction of an intended replacement, the unibody SUV Mercedes-Benz GL-Class in 2006, the G-Class is still in production and is one of the longest produced vehicles in Daimler's history, with a span of 40 years. Only the Unimog surpasses it.",
                Mileage = 48666,
                User = user,
                UserId = user.Id,
                VehicleCategory = vehicleCategoriesService.GetVehicleCategoryByName("Jeep"),
                VehicleCategoryId = vehicleCategoriesService.GetVehicleCategoryByName("Jeep").Id,
                EngineType = EngineType.Petrol,
                Currency = Currency.LV,
                Condition = Condition.Used,
                PhoneNumber = "0896321478",
                ManufactureDate = new DateTime(2018, 4, 2),
                TransmissionType = TransmissionType.Automatic,
                Price = 125478,
                Email = user.Email,
            };

            await postsService.AddAsync(bmwM5e60);
            await postsService.AddAsync(bmwM5f10);
            await postsService.AddAsync(bmwM3f80);
            await postsService.AddAsync(audiRS7);
            await postsService.AddAsync(mercedesS600);
            await postsService.AddAsync(audiRS6);
            await postsService.AddAsync(mercedesGClass);
            await dbContext.SaveChangesAsync();

            for (int i = 0; i < allImages.Count; i++)
            {
                if (i >= 0 && i <= 3)
                {
                    var postImage = new PostImage()
                    {
                        Image = allImages[i],
                        ImageId = allImages[i].Id,
                        Post = bmwM5e60,
                        PostId = bmwM5e60.Id,
                    };

                    bmwM5e60.Images.Add(postImage);
                }
                else if (i >= 4 && i <= 7)
                {
                    var postImage = new PostImage()
                    {
                        Image = allImages[i],
                        ImageId = allImages[i].Id,
                        Post = audiRS7,
                        PostId = audiRS7.Id,
                    };

                    audiRS7.Images.Add(postImage);
                }
                else if (i >= 8 && i <= 11)
                {
                    var postImage = new PostImage()
                    {
                        Image = allImages[i],
                        ImageId = allImages[i].Id,
                        Post = mercedesS600,
                        PostId = mercedesS600.Id,
                    };

                    mercedesS600.Images.Add(postImage);
                }
                else if (i >= 12 && i <= 15)
                {
                    var postImage = new PostImage()
                    {
                        Image = allImages[i],
                        ImageId = allImages[i].Id,
                        Post = bmwM3f80,
                        PostId = bmwM3f80.Id,
                    };

                    bmwM3f80.Images.Add(postImage);
                }
                else if (i >= 16 && i <= 18)
                {
                    var postImage = new PostImage()
                    {
                        Image = allImages[i],
                        ImageId = allImages[i].Id,
                        Post = bmwM5f10,
                        PostId = bmwM5f10.Id,
                    };

                    bmwM5f10.Images.Add(postImage);
                }
                else if (i >= 19 && i <= 22)
                {
                    var postImage = new PostImage()
                    {
                        Image = allImages[i],
                        ImageId = allImages[i].Id,
                        Post = audiRS6,
                        PostId = audiRS6.Id,
                    };

                    audiRS6.Images.Add(postImage);
                }
                else if (i >= 23 && i <= 26)
                {
                    var postImage = new PostImage()
                    {
                        Image = allImages[i],
                        ImageId = allImages[i].Id,
                        Post = mercedesGClass,
                        PostId = mercedesGClass.Id,
                    };

                    mercedesGClass.Images.Add(postImage);
                }
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
