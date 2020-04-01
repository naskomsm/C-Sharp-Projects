namespace Sabv.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Sabv.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        public Comment()
        {
            this.UserLikes = new HashSet<UserLikes>();
        }

        [Required]
        public string Content { get; set; }

        [Required]
        public int PostId { get; set; }

        [Required]
        public virtual Post Post { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<UserLikes> UserLikes { get; set; }
    }
}
