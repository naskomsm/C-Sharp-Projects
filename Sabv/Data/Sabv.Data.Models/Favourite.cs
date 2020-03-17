namespace Sabv.Data.Models
{
    using Sabv.Data.Common.Models;

    public class Favourite : BaseDeletableModel<int>
    {
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
