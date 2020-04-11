namespace Sabv.Web.ViewModels.Posts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Mvc.Rendering;

    public class SearchViewModel
    {
        public string Category { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public string Make { get; set; }

        public List<SelectListItem> Makes { get; set; }

        public string VehicleCategory { get; set; }

        public List<SelectListItem> VehicleCategories { get; set; }

        public string Color { get; set; }

        public List<SelectListItem> Colors { get; set; }

        public string City { get; set; }

        public List<SelectListItem> Cities { get; set; }

        public string EngineType { get; set; }

        public List<SelectListItem> EngineTypes { get; set; }

        public string Eurostandard { get; set; }

        public List<SelectListItem> Eurostandards { get; set; }

        public string TransmissionType { get; set; }

        public List<SelectListItem> TransmissionTypes { get; set; }

        public string Currency { get; set; }

        public List<SelectListItem> Currencies { get; set; }

        public int YearFrom { get; set; }

        public List<SelectListItem> YearsFrom { get; set; }

        public int YearTo { get; set; }

        public List<SelectListItem> YearsTo { get; set; }

        public int MaxMileage { get; set; }

        public int MinHorsepower { get; set; }

        public int MaxHorsepower { get; set; }

        public int PriceFrom { get; set; }

        public int PriceTo { get; set; }
    }
}
