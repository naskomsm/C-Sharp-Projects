namespace Sabv.Data.Models
{
    public class PostImage
    {
        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        public int ImageId { get; set; }

        public virtual Image Image { get; set; }
    }
}
