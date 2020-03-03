namespace Sabv.Web.ViewModels.Posts
{
    using System.Collections.Generic;

    using Sabv.Data.Models.Posts;

    public class AllPostsViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
    }
}
