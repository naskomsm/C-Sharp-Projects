namespace Sabv.Web.ViewModels.Posts
{
    using System;

    using Sabv.Data.Models.Categories;
    using Sabv.Data.Models.Cities;
    using Sabv.Data.Models.Enums;
    using Sabv.Data.Models.Makes;
    using Sabv.Data.Models.Models;

    public class CheckTextViewModel
    {
        public Category Category { get; set; }

        public string PhoneNumber { get; set; }

        public Make Make { get; set; }

        public Model Model { get; set; }

        public decimal Price { get; set; }

        public Currency Currency { get; set; }

        public EngineType EngineType { get; set; }

        public Eurostandard Eurostandard { get; set; }

        public TransmissionType TransmissionType { get; set; }

        public VehicleCategory VehicleCategory { get; set; }

        public int Mileage { get; set; }

        public DateTime ManufactureDate { get; set; }

        public string Color { get; set; }

        public City City { get; set; }

        public string Email { get; set; }
    }
}
