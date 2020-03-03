namespace Sabv.Web.ViewModels.Posts
{
    using System;
    using System.Collections.Generic;

    using Sabv.Data.Models.Categories;
    using Sabv.Data.Models.Cities;
    using Sabv.Data.Models.Enums;
    using Sabv.Data.Models.Extras;
    using Sabv.Data.Models.PostsImages;

    public class DetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public City City { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime VehicleManufactureDate { get; set; }

        public EngineType EngineType { get; set; }

        public int Horsepower { get; set; }

        public Eurostandard Eurostandard { get; set; }

        public TransmissionType TransmissionType { get; set; }

        public VehicleCategory VehicleCategory { get; set; }

        public int Mileage { get; set; }

        public string Color { get; set; }

        public Safety Safety { get; set; }

        public Comfort Comfort { get; set; }

        public Exterior Exterior { get; set; }

        public Other Other { get; set; }

        public string Description { get; set; }

        public ICollection<PostImage> Images { get; set; }
    }
}
