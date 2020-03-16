namespace Sabv.Web.ViewModels.Comments
{
    using System.Collections.Generic;

    using Sabv.Data.Models;

    public class CommentsAdminPanel
    {
        public IEnumerable<Comment> Comments { get; set; }
    }
}
