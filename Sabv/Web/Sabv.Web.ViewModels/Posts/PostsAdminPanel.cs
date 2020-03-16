namespace Sabv.Web.ViewModels.Posts
{
    using System.Collections.Generic;

    using Sabv.Data.Models;

    public class PostsAdminPanel
    {
        public IEnumerable<Post> Posts { get; set; }
    }
}
