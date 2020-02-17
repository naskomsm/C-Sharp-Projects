namespace Sabv.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Sabv.Data.Common.Models;

    public class PostCategory : BaseModel<string>
    {
        public PostCategory()
        {
            this.Id = Guid.NewGuid().ToString();

            // Collections
            this.Posts = new HashSet<Post>();
        }

        [Required]
        [MaxLength(DataValidation.Common.MaxLength)]
        public string Name { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
