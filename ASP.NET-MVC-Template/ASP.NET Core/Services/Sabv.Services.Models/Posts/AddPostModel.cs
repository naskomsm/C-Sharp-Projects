namespace Sabv.Services.Models.Posts
{
    public class AddPostModel
    {
        public string Name { get; set; }

        public string Make { get; set; }

        public int Condition { get; set; }

        public int Currency { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string PhoneNumber { get; set; }

        public string UserId { get; set; }

        public string MainInfoId { get; set; }

        public string AdditionalInfoId { get; set; }

        public string VehicleCategoryId { get; set; }

        public string PostCategoryId { get; set; }
    }
}
