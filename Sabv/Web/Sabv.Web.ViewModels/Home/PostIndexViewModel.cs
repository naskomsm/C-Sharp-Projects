namespace Sabv.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using Sabv.Data.Models;
    using Sabv.Data.Models.Enums;
    using Sabv.Services.Mapping;

    public class PostIndexViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Mileage { get; set; }

        public City City { get; set; }

        public Currency Currency { get; set; }

        public ICollection<PostImage> Images { get; set; }
    }
}
