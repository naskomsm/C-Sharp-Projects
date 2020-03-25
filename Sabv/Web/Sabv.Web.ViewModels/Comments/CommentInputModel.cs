namespace Sabv.Web.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;

    public class CommentInputModel
    {
        [Required]
        [MinLength(1)]
        public string Content { get; set; }

        [Required]
        public int PostId { get; set; }
    }
}
