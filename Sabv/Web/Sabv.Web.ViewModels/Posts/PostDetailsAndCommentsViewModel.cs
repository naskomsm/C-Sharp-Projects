namespace Sabv.Web.ViewModels.Posts
{
    using Sabv.Web.ViewModels.Comments;

    public class PostDetailsAndCommentsViewModel
    {
        public PostDetailsViewModel PostDetails { get; set; }

        public CommentViewModel CommentViewModel { get; set; }
    }
}
