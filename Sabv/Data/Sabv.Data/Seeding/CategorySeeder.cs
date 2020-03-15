namespace Sabv.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;
    using Sabv.Services.Data;

    public class CategorySeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            var categoriesService = serviceProvider.GetRequiredService<ICategoriesService>();
            var cloudinaryService = serviceProvider.GetRequiredService<ICloudinaryService>();



            var categories = new List<(string Name, string ImageUrl, string Description)>()
            {
                ("Cars and jeeps", "https://clipartart.com/images/car-clipart-image-7.png", @" A car (or automobile) is a wheeled motor vehicle used for transportation. Most definitions of cars say that they run primarily on roads, 
            seat one to eight people, have four tires, and mainly transport people rather than goods. Cars came into global use during the 20th century, 
            and developed economies depend on them. The year 1886 is regarded as the birth year of the modern car when German inventor Karl Benz patented 
            his Benz Patent-Motorwagen. Cars became widely available in the early 20th century. One of the first cars accessible to the masses was the 1908 
            Model T, an American car manufactured by the Ford Motor Company. Cars were rapidly adopted in the US, where they replaced animal-drawn carriages 
            and carts, but took much longer to be accepted in Western Europe and other parts of the world. Cars have controls for driving, parking, passenger 
            comfort, and a variety of lights. Over the decades, additional features and controls have been added to vehicles, making them progressively more 
            complex, but also more reliable and easier to operate. These include rear reversing cameras, air conditioning, navigation systems, and in-car 
            entertainment. Most cars in use in the 2010s are propelled by an internal combustion engine, fueled by the combustion of fossil fuels. Electric
            cars, which were invented early in the history of the car, became commercially available in the 2000s and are predicted to cost less to buy than
            gasoline cars before 2025. There are costs and benefits to car use. The costs to the individual include acquiring the vehicle, interest payments 
            (if the car is financed), repairs and maintenance, fuel, depreciation, driving time, parking fees, taxes, and insurance. The costs to society 
            include maintaining roads, land use, road congestion, air pollution, public health, health care, and disposing of the vehicle at the end of its life. 
            Traffic collisions are the largest cause of injury-related deaths worldwide. The personal benefits include on-demand transportation, mobility, 
            independence, and convenience. The societal benefits include economic benefits, such as job and wealth creation from the automotive 
            industry, transportation provision, societal well-being from leisure and travel opportunities, and revenue generation from the taxes. 
            People's ability to move flexibly from place to place has far-reaching implications for the nature of societies. There are around 1 billion 
            cars in use worldwide. The numbers are increasing rapidly, especially in China, India and other newly industrialized countries."),
                ("Buses", "https://i7.pngguru.com/preview/690/72/59/tour-bus-service-minibus-sleeper-bus-school-bus-bus.jpg", @"A bus (contracted from omnibus, with variants multibus, motorbus, autobus, etc.) is a road vehicle designed to carry many passengers. 
            Buses can have a capacity as high as 300 passengers. The most common type is the single-deck rigid bus, with larger loads carried by 
            double-decker and articulated buses, and smaller loads carried by midibuses and minibuses while coaches are used for longer-distance services. 
            Many types of buses, such as city transit buses and inter-city coaches, charge a fare. Other types, such as elementary or secondary school 
            buses or shuttle buses within a post-secondary education campus do not charge a fare. In many jurisdictions, bus drivers require a special 
            licence above and beyond a regular driver's licence. Buses may be used for scheduled bus transport, scheduled coach transport, school 
            transport, private hire, or tourism; promotional buses may be used for political campaigns and others are privately operated for a wide 
            range of purposes, including rock and pop band tour vehicles. Horse-drawn buses were used from the 1820s, followed by steam buses in the 
            1830s, and electric trolleybuses in 1882. The first internal combustion engine buses, or motor buses, were used in 1895. Recently, interest 
            has been growing in hybrid electric buses, fuel cell buses, and electric buses, as well as buses powered by compressed natural gas or biodiesel.
            As of the 2010s, bus manufacturing is increasingly globalised, with the same designs appearing around the world."),
                ("Trucks",  "https://p7.hiclipart.com/preview/693/127/604/mover-pickup-truck-c-h-robinson-transport-truck.jpg", @" A truck or lorry is a motor vehicle designed to transport cargo. Trucks vary greatly in size, power, and configuration; smaller varieties may 
            be mechanically similar to some automobiles. Commercial trucks can be very large and powerful and may be configured to be mounted with 
            specialized equipment, such as in the case of refuse trucks, fire trucks, concrete mixers, and suction excavators. In American English, 
            a commercial vehicle without a trailer or other articulation is formally a ""straight truck"" while one designed specifically to pull a 
            trailer is not a truck but a ""tractor"". Modern trucks are largely powered by diesel engines, although small to medium size trucks with
            gasoline engines exist in the US, Canada, and Mexico. In the European Union, vehicles with a gross combination mass of up to 3.5 t (7,700 lb)
            are known as light commercial vehicles, and those over as large goods vehicles."),
                ("Motorcycles", "https://www.stickpng.com/assets/images/580b585b2edbce24c47b2d05.png", @" A motorcycle, often called a motorbike, bike, or cycle, is a two- or three-wheeled motor vehicle. Motorcycle design varies greatly to suit 
            a range of different purposes: long distance travel, commuting, cruising, sport including racing, and off-road riding. Motorcycling is riding 
            a motorcycle and related social activity such as joining a motorcycle club and attending motorcycle rallies. The 1885 Daimler Reitwagen made
            by Gottlieb Daimler and Wilhelm Maybach in Germany was the first internal combustion, petroleum fueled motorcycle. In 1894, Hildebrand & 
            Wolfmüller became the first series production motorcycle. In 2014, the three top motorcycle producers globally by volume were Honda (28%), 
            Yamaha (17%) (both from Japan), and Hero MotoCorp (India). In developing countries, motorcycles are considered utilitarian due to lower 
            prices and greater fuel economy. Of all the motorcycles in the world, 58% are in the Asia-Pacific and Southern and Eastern Asia regions, 
            excluding car-centric Japan. According to the US Department of Transportation the number of fatalities per vehicle mile traveled was 37 
            times higher for motorcycles than for cars."),
            };

            foreach (var (name, imageUrl, description) in categories)
            {
                var image = await cloudinaryService.UploadAsync(imageUrl);
                await categoriesService.AddAsync(name, image, description);
            }
        }
    }
}
