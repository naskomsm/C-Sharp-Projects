namespace SellAndBuyVehicles.Data.Models
{
    public class PostPicture
    {
        public int PostId { get; set; }

        public Post Post { get; set; }

        public int PictureId { get; set; }

        public Picture Picture { get; set; }
    }
}
