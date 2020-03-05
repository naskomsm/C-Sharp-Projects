namespace Sabv.Data.Models.Posts
{
    using System;
    using System.Collections.Generic;

    using Sabv.Data.Common.Models;
    using Sabv.Data.Models.Categories;
    using Sabv.Data.Models.Cities;
    using Sabv.Data.Models.Enums;
    using Sabv.Data.Models.Extras;
    using Sabv.Data.Models.Images;
    using Sabv.Data.Models.Makes;
    using Sabv.Data.Models.Models;
    using Sabv.Data.Models.PostsImages;
    using Sabv.Data.Models.Users;

    public class Post : BaseDeletableModel<int>
    {
        public Post()
        {
            this.Images = new HashSet<PostImage>();
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

        public int VehicleCategoryId { get; set; }

        public virtual VehicleCategory VehicleCategory { get; set; }

        public Condition Condition { get; set; }

        public int Mileage { get; set; }

        public string Color { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int MakeId { get; set; }

        public virtual Make Make { get; set; }

        public int ModelId { get; set; }

        public virtual Model Model { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        public int SafetyId { get; set; }

        public virtual Safety Safety { get; set; }

        public int ExteriorId { get; set; }

        public virtual Exterior Exterior { get; set; }

        public int ComfortId { get; set; }

        public virtual Comfort Comfort { get; set; }

        public int OtherId { get; set; }

        public virtual Other Other { get; set; }

        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<PostImage> Images { get; set; }
    }
}
