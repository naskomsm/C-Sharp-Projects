namespace Sabv.Data.Models.Images
{
    using System.Collections.Generic;

    using Sabv.Data.Common.Models;
    using Sabv.Data.Models.PostsImages;

    public class Image : BaseDeletableModel<int>
    {
        public Image()
        {
            this.Posts = new HashSet<PostImage>();
        }

        public string Url { get; set; }

        public virtual ICollection<PostImage> Posts { get; set; }
    }
}
