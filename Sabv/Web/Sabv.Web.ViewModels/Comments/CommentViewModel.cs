namespace Sabv.Web.ViewModels.Comments
{
    using System.Collections.Generic;

    using Sabv.Data.Models;

    public class CommentViewModel
    {
        public int PostId { get; set; }

        public ApplicationUser User { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
    }
}
