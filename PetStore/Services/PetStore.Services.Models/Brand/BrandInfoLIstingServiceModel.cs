namespace PetStore.Services.Models.Brand
{
    using Toy;
    using Food;
    using System.Collections.Generic;

    public class BrandInfoLIstingServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ToyListingServiceModel> Toys { get; set; }

        public IEnumerable<FoodListingServiceModel> Food { get; set; }
    }
}
