namespace Sabv.Web.ViewModels.Posts
{
    using System;
    using System.Collections.Generic;

    using Sabv.Data.Models;
    using Sabv.Data.Models.Enums;
    using Sabv.Services.Mapping;

    public class PostDetailsViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public Currency Currency { get; set; }

        public ICollection<PostImage> Images { get; set; }

        public ApplicationUser User { get; set; }

        public City City { get; set; }

        public string PhoneNumber { get; set; }

        public string Description { get; set; }

        public DateTime ManufactureDate { get; set; }

        public EngineType EngineType { get; set; }

        public int Horsepower { get; set; }

        public Eurostandard Eurostandard { get; set; }

        public TransmissionType TransmissionType { get; set; }

        public Condition Condition { get; set; }

        public int Mileage { get; set; }

        public VehicleCategory VehicleCategory { get; set; }

        public Color Color { get; set; }
    }
}
