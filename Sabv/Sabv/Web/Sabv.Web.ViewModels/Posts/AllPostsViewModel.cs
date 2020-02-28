namespace Sabv.Web.ViewModels.Posts
{
    using System.Collections.Generic;

    public class AllPostsViewModel
    {
        public ICollection<PostViewModel> Posts { get; set; }
    }
}
