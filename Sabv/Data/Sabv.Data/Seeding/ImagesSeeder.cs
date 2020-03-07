namespace Sabv.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;
    using Sabv.Services.Data;

    public class ImagesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Images.Any())
            {
                return;
            }

            var service = serviceProvider.GetRequiredService<ICloudinaryService>();

            var links = new List<string>()
            {
                "https://www.kindpng.com/picc/m/24-248729_stockvader-predicted-adig-user-profile-image-png-transparent.png",
                "https://images.unsplash.com/photo-1523676060187-f55189a71f5e?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&w=1000&q=80",
                "https://upload.wikimedia.org/wikipedia/commons/thumb/9/96/Kohlhof_Wagen.JPG/1200px-Kohlhof_Wagen.JPG",
                "https://drop.ndtv.com/albums/AUTO/porsche-taycan-turbo/6401200x900_1_640x480.jpg",
                "https://media.wired.com/photos/5d09594a62bcb0c9752779d9/master/pass/Transpo_G70_TA-518126.jpg",
                "https://imgd.aeplcdn.com/1056x594/cw/ec/35455/Hyundai-Venue-Exterior-154436.jpg?wm=0&q=85",
                "https://www.autocar.co.uk/sites/autocar.co.uk/files/styles/body-image/public/911-road-3629a.jpg?itok=m6x23Go0",
                "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSDB-cL-RAxvDvp4cfrr9RNRfhC0irTC_s_rbF-xaiZDQbkvzTM",
                "https://f1.media.brightcove.com/8/1078702682/1078702682_6004950245001_6004956161001-vs.jpg?pubId=1078702682&videoId=6004956161001",
                "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcTi3YqLy1HrsAuSkXyfJeY26kufypah1Epbl2bQC6bw-MK2Mf62",
                "https://static-ssl.businessinsider.com/image/5d9b5bff52887931e8497a36-1405/141222twnmustang.jp2",
                "https://www.bentleymotors.com/content/dam/bentley/Master/homepage%20carousel/Bentley-Mulliner-Bacalar-front-three-quarter-hpc-1920x1080.jpg/_jcr_content/renditions/Bentley-Mulliner-Bacalar-front-three-quarter-hpc-1024x576.jpg.image_file.700.394.file/Bentley-Mulliner-Bacalar-front-three-quarter-hpc-1024x576.jpg",
                "https://lionrentacar.bg/data/ufiles/images/cars/image/tn/peugeot%20508%20for%20rent-1.jpeg",
                "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcQFlxlTgo6tVYuoeOumJ3fGzMis1jkstMS_DbjWM6xbYuqtuKIX",
                "https://lionrentacar.bg/data/ufiles/images/cars/image/tn/308-2019.jpg",
                "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSA-8sp-CDy11F9aTb6sweZ1ygR1WO2ObZ5scIfdLW0pyPxKH5F",
                "https://www.topgear.com/sites/default/files/images/cars-road-test/2019/12/8265f91b5587b4cf28695e35507c1f0f/_dsc3905.jpg",
                "https://akm-img-a-in.tosshub.com/sites/btmt/images/stories/maruti_suzuki_s_presso_660_191119010952.jpg",
                "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcQ9EsC21HFBiPvb9DC3Po9ofW_9WhQ_CJckB_feuH3bwgJj5pcx",
                "https://www.bentleymotors.com/content/dam/bentley/Master/homepage%20carousel/Continental-GT-Mullliner-Convertible-studio-front-34-hpc-1920x1080.jpg/_jcr_content/renditions/Continental-GT-Mullliner-Convertible-studio-front-34-hpc-1024x576.jpg.image_file.700.394.file/Continental-GT-Mullliner-Convertible-studio-front-34-hpc-1024x576.jpg",
                "https://images.cnbctv18.com/wp-content/uploads/2020/01/MB-AVTR-1.jpg",
            };

            foreach (var link in links)
            {
                await service.UploadAsync(link);
            }
        }
    }
}
