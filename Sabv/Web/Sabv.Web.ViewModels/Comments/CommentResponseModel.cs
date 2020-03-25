namespace Sabv.Web.ViewModels.Comments
{
    public class CommentResponseModel
    {
        public string Username { get; set; }

        public string Content { get; set; }

        public string CurrentUserImageUrl { get; set; }

        public int CommentId { get; set; }

        public int PostId { get; set; }
    }
}
