namespace Sabv.Data.Models.Models
{
    using Sabv.Data.Common.Models;
    using Sabv.Data.Models.Makes;

    public class Model : BaseModel<int>
    {
        public string Name { get; set; }

        public int MakeId { get; set; }

        public virtual Make Make { get; set; }
    }
}
