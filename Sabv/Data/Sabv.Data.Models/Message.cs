namespace Sabv.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Sabv.Data.Common.Models;

    public class Message : BaseDeletableModel<int>
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
