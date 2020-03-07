namespace Sabv.Data.Models
{
    using Sabv.Data.Common.Models;
    using Sabv.Services.Mapping;

    public class Model : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public int MakeId { get; set; }

        public virtual Make Make { get; set; }
    }
}
