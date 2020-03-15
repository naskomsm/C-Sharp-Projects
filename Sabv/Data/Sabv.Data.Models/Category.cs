namespace Sabv.Data.Models
{
    using Sabv.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int ImageId { get; set; }

        public virtual Image Image { get; set; }
    }
}
