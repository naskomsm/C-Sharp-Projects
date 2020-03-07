namespace Sabv.Data.Models
{
    using System.Collections.Generic;

    using Sabv.Data.Common.Models;

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
