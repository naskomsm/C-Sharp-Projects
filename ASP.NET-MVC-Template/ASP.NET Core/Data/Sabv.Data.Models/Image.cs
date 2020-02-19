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
        [MaxLength(DataValidation.Common.MaxLength)]
        public string Title { get; set; }

        // Relations
        [Required]
        public string PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
