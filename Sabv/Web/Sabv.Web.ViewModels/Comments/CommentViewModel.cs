namespace Sabv.Web.ViewModels.Comments
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Sabv.Data.Models;

    public class CommentViewModel
    {
        [Required]
        public int PostId { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
    }
}
