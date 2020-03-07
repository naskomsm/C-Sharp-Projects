namespace Sabv.Web.ViewModels.Posts
{
    using System;
    using System.Collections.Generic;

    using Sabv.Data.Models;
    using Sabv.Data.Models.Enums;
    using Sabv.Services.Mapping;

    public class AllPagePostViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public Currency Currency { get; set; }

        public int Mileage { get; set; }

        public Color Color { get; set; }

        public EngineType EngineType { get; set; }

        public int Horsepower { get; set; }

        public TransmissionType TransmissionType { get; set; }

        public DateTime ManufactureDate { get; set; }

        public ICollection<PostImage> Images { get; set; }
    }
}
