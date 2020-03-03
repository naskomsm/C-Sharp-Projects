namespace Sabv.Data.Models.PostsImages
{

    using Sabv.Data.Models.Images;
    using Sabv.Data.Models.Posts;

    public class PostImage
    {
        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        public int ImageId { get; set; }

        public virtual Image Image { get; set; }
    }
}
