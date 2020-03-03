namespace Sabv.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using Sabv.Common;
    using Sabv.Data.Models.Enums;
    using Sabv.Data.Models.Posts;
    using Sabv.Data.Models.PostsImages;
    using Sabv.Data.Models.Users;
    using Sabv.Services.Data;

    public class PostsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var postsService = serviceProvider.GetRequiredService<IPostsService>();
            var extrasService = serviceProvider.GetRequiredService<IExtrasService>();
            var vehicleCategoryService = serviceProvider.GetRequiredService<IVehicleCategoryService>();
            var categoryService = serviceProvider.GetRequiredService<ICategoryService>();
            var makesService = serviceProvider.GetRequiredService<IMakesService>();
            var citiesService = serviceProvider.GetRequiredService<ICitiesService>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var cloudinary = serviceProvider.GetRequiredService<ICloudinaryService>();
            var imagesService = serviceProvider.GetRequiredService<IImageService>();
            var modelsService = serviceProvider.GetRequiredService<IModelsService>();

            await SeedPostsAsync(
                postsService,
                extrasService,
                vehicleCategoryService,
                categoryService,
                makesService,
                citiesService,
                userManager,
                cloudinary,
                imagesService,
                modelsService);
        }

        private static async Task SeedPostsAsync(
            IPostsService postsService,
            IExtrasService extrasService,
            IVehicleCategoryService vehicleCategoryService,
            ICategoryService categoryService,
            IMakesService makesService,
            ICitiesService citiesService,
            UserManager<ApplicationUser> userManager,
            ICloudinaryService cloudinaryService,
            IImageService imageService,
            IModelsService modelsService)
        {
            var opelImageUrl = "https://autodata24.com/i/opel/astra/astra-gtc-h/large/5e7bcd18438ab7940b0bb84b9734134f.jpg";
            var audiImageUrl = "https://i.insider.com/59bca6f79803c5b3308b635a?width=1136&format=jpeg";
            var bmwImageUrl = "https://cdn.bringatrailer.com/wp-content/uploads/2019/05/2007_bmw_m5_15595811056865a23DSC01316-940x607.jpg";

            await cloudinaryService.UploadAsync(GlobalConstants.DefaultImageForPost);

            await cloudinaryService.UploadAsync(bmwImageUrl);
            await cloudinaryService.UploadAsync(audiImageUrl);
            await cloudinaryService.UploadAsync(opelImageUrl);

            var firstPost = new Post()
            {
                ApplicationUserId = userManager.Users.ToArray()[0].Id,
                ApplicationUser = userManager.Users.ToArray()[0],
                Category = categoryService.GetById(1),
                CategoryId = 1,
                City = citiesService.GetById(1),
                CityId = 1,
                Color = "Син",
                Comfort = extrasService.GetByIdComfort(1),
                ComfortId = 1,
                CreatedOn = DateTime.UtcNow,
                Description = "Продава се М5 Е60 на 117300 РЕАЛНИ километра. Колата е в отлично състояние и е обслужвана само и едиствено в оторизирани представителства на марката със фактури на обща стойност над 25 000 лв. Сменени: биелни лагери+ванос линия високо налягане, съединител+маховик, 10 свещи, предни дискове и накладки, 2 ламбда сонди, водна помпа, ролки, ремъци, 2 стъпкови моторчета, изцяло ревизиран SMG hydraulic unit със сменен ел. мотор+ механична помпа (при покой 24< часа помпата нагнетява за не повече от 5-7 секунди), clutch positioning sensor, clutch slave valve, 2 носача, както и още други неща. всички ремонти са извършени в диапазона от 12-5к километра. Като модификации колата има къстъм генерация JS-design с ел. клапа към straight pipe (със стокови колектори), eibach пружини със снижаване (по спомен) 30мм отпред и 15мм отзад, фейслифт стопове със фейс лайт модул, фаровете са със къстъм ретрофир извършен от CL workshox, Japan Racing джанти 8, 5 и 9, 5 на 10к километра със нови гуми, Android навигация със камера за заден ход, софтуер на кутията от ESS tuning, цялостно нано-керамично покритие. Автомобила е във изпълнение със алкантара таван и цялостен кожен пакет на интериора. На дино в Маднес колата има изкарани 490+ к. с. във абсолютен стоков вариант. Сериозен автомобил за ценители обгрижван на 100% без никакви компромиси. Без тестови пилоти. Бартери не ме интересуват.",
                EngineType = EngineType.Petrol,
                Eurostandard = Eurostandard.Four,
                Exterior = extrasService.GetByIdExterior(1),
                ExteriorId = 1,
                Horsepower = 507,
                Make = makesService.GetById(1),
                MakeId = 1,
                ManufactureDate = DateTime.UtcNow.AddDays(-150),
                IsDeleted = false,
                Mileage = 150000,
                Name = makesService.GetById(1).Name + " " + modelsService.GetById(1).Name,
                Model = modelsService.GetById(1),
                ModelId = 1,
                Other = extrasService.GetByIdOther(1),
                OtherId = 1,
                PhoneNumber = "0899115617",
                Price = 49500,
                Safety = extrasService.GetByIdSafety(1),
                SafetyId = 1,
                TransmissionType = TransmissionType.Automatic,
                VehicleCategory = vehicleCategoryService.GetById(1),
                VehicleCategoryId = 1,
            };

            var secondPost = new Post()
            {
                ApplicationUserId = userManager.Users.ToArray()[0].Id,
                ApplicationUser = userManager.Users.ToArray()[0],
                Category = categoryService.GetById(1),
                CategoryId = 1,
                City = citiesService.GetById(2),
                CityId = 2,
                Color = "Черен",
                Comfort = extrasService.GetByIdComfort(1),
                ComfortId = 1,
                CreatedOn = DateTime.UtcNow,
                Description = "Наличен, , Цвят тъмно син металик, кожен салон Valcona с контрастни шевове тип пчелна пита, RS спортни седалки с RS релеф, Керамични спирачки, 4х4 перманентно задвижване, Автоматична скоростна кутия, отопляеми огледала, шибидах електрически, ксенонова светлина, система за почистване на фаровете, LED задни светлини, LED дневни светлини, автоматични огледала със затъмняване, Dynamic мигаща светлина, LED матрични фарове, лумбална опора, подлакътник, Орнаменти от дърво, автоматична климатична инсталация, кожен салон, пакет за съхранение, зарядно устройство, автоматично затъмняване на вътрешното огледало, Парктроник, тракшън контрол, въздушна възглавница за водача, ръководител на въздушните възглавници, централно заключване. ESP (електронна програма за стабилност), круиз контрол, спортно окачване, имобилайзер, Серво, Странични въздушни възглавници, Adaptive Cruise Control, Електрически заден капак, удобство ключ (влизане без ключ), предупреждение при напускане на лентата, асистент за паркиране, старт / стоп система, предна камера, камера за задно виждане, регулиране обсега на предните фарове, Head up дисплей (HUD), дневни светлини, контрол на налягането в гумите, ел заключване на вратите, система за ранно предупреждение злополука, спирачен асистент, динамичен контрол на фаровете гама, динамично управление, Алуминиеви джанти, Мултифункционален волан, ел Регулиране на волана, Електрически седалки, Памет седалки, Подгрев на седалките, Спортни седалки, ел стъкла, ел огледала с подгрев и прибиране, Bang & Olufsen озвучителна система с 3D звук, Бордови компютър информационна система, навигационна система с цветен монитор, телевизор приемник, цифров радио тунер, входно устройство (тъчпад), Лизинг! За повече информация info@isauto. net",
                EngineType = EngineType.Disel,
                Eurostandard = Eurostandard.Five,
                Exterior = extrasService.GetByIdExterior(1),
                ExteriorId = 1,
                Horsepower = 605,
                Make = makesService.GetById(2),
                MakeId = 2,
                ManufactureDate = DateTime.UtcNow.AddDays(-150),
                IsDeleted = false,
                Mileage = 56215,
                ModelId = 2,
                Model = modelsService.GetById(2),
                Name = makesService.GetById(2).Name + " " + modelsService.GetById(2).Name,
                Other = extrasService.GetByIdOther(1),
                OtherId = 1,
                PhoneNumber = "0899115617",
                Price = 166000,
                Safety = extrasService.GetByIdSafety(1),
                SafetyId = 1,
                TransmissionType = TransmissionType.Automatic,
                VehicleCategory = vehicleCategoryService.GetById(1),
                VehicleCategoryId = 1,
            };

            var thirdPost = new Post()
            {
                ApplicationUserId = userManager.Users.ToArray()[0].Id,
                ApplicationUser = userManager.Users.ToArray()[0],
                Category = categoryService.GetById(1),
                CategoryId = 1,
                City = citiesService.GetById(3),
                CityId = 3,
                Color = "Червен",
                Comfort = extrasService.GetByIdComfort(1),
                ComfortId = 1,
                CreatedOn = DateTime.UtcNow,
                Description = "Колата е в перфектно техническо състояние. Има забележки по ламарината, но това е поправимо. Много икономична. Разход около 7/100 в София и около 5/100 извън града. Колата е в Плевен и може да се види по всяко време с един час предварителна договорка. Десен волан.ПРОДАДЕНА",
                EngineType = EngineType.Disel,
                Eurostandard = Eurostandard.Four,
                Exterior = extrasService.GetByIdExterior(1),
                ExteriorId = 1,
                Horsepower = 150,
                Make = makesService.GetById(3),
                MakeId = 3,
                ManufactureDate = DateTime.UtcNow.AddDays(-150),
                IsDeleted = false,
                Mileage = 250000,
                ModelId = 2,
                Model = modelsService.GetById(2),
                Name = makesService.GetById(3).Name + " " + modelsService.GetById(3).Name,
                Other = extrasService.GetByIdOther(1),
                OtherId = 1,
                PhoneNumber = "0899115617",
                Price = 5000,
                Safety = extrasService.GetByIdSafety(1),
                SafetyId = 1,
                TransmissionType = TransmissionType.Manual,
                VehicleCategory = vehicleCategoryService.GetById(1),
                VehicleCategoryId = 1,
            };

            firstPost.Images.Add(new PostImage { ImageId = 2, Post = firstPost });
            secondPost.Images.Add(new PostImage { ImageId = 3, Post = secondPost });
            thirdPost.Images.Add(new PostImage { ImageId = 4, Post = thirdPost });

            await postsService.AddAsync(firstPost);
            await postsService.AddAsync(secondPost);
            await postsService.AddAsync(thirdPost);
        }
    }
}
