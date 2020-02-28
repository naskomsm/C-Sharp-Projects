namespace Sabv.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Sabv.Data.Common.Models;

    public class Image : BaseDeletableModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        // Specific
        [Required]
        public string Url { get; set; }

        // Relations
        public string PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
