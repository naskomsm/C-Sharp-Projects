namespace Sabv.Data.Models.Makes
{
    using System.Collections.Generic;

    using Sabv.Data.Common.Models;
    using Sabv.Data.Models.Models;

    public class Make : BaseModel<int>
    {
        public string Name { get; set; }

        public virtual ICollection<Model> Models { get; set; }
    }
}
