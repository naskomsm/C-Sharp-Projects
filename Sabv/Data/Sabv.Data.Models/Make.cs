namespace Sabv.Data.Models
{
    using System.Collections.Generic;

    using Sabv.Data.Common.Models;
    using Sabv.Services.Mapping;

    public class Make : BaseDeletableModel<int>
    {
        public Make()
        {
            this.Models = new HashSet<Model>();
        }

        public string Name { get; set; }

        public virtual ICollection<Model> Models { get; set; }
    }
}
