namespace Sabv.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Sabv.Data.Common.Models;
    using Sabv.Data.Models.Enums;
    using Sabv.Services.Mapping;

    public class Post : BaseDeletableModel<int>
    {
        public Post()
        {
            this.Images = new HashSet<PostImage>();
            this.Comments = new HashSet<Comment>();
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public Currency Currency { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        public DateTime ManufactureDate { get; set; }

        public EngineType EngineType { get; set; }

        public int Horsepower { get; set; }

        public Eurostandard Eurostandard { get; set; }

        public TransmissionType TransmissionType { get; set; }

        public Condition Condition { get; set; }

        public int Mileage { get; set; }

        // Relations
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int VehicleCategoryId { get; set; }

        public virtual VehicleCategory VehicleCategory { get; set; }

        public int ColorId { get; set; }

        public virtual Color Color { get; set; }

        public int MakeId { get; set; }

        public virtual Make Make { get; set; }

        public int ModelId { get; set; }

        public virtual Model Model { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<PostImage> Images { get; set; }
    }
}
