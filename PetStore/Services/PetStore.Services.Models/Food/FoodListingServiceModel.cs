namespace PetStore.Services.Models.Food
{
    public class FoodListingServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ExpireDate { get; set; }

        public double Weight { get; set; }
    }
}
