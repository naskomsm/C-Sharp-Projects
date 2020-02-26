namespace Sabv.Data.Models.AdditionalInfoFiles
{
    using System;
    using System.Collections.Generic;

    using Sabv.Data.Common.Models;
    using Sabv.Data.Models.AdditioalInfoFiles;

    public class AdditionalInfo : BaseDeletableModel<string>
    {
        public AdditionalInfo()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Posts = new HashSet<Post>();
        }

        public string Town { get; set; }

        public int ComfortInfoId { get; set; }

        public virtual ComfortInfo ComfortInfo { get; set; }

        public virtual ExteriorInfo ExteriorInfo { get; set; }

        public int ExteriorInfoId { get; set; }

        public virtual SafetyInfo SafetyInfo { get; set; }

        public int SafetyInfoId { get; set; }

        public virtual OtherInfo OtherInfo { get; set; }

        public int OtherInfoId { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
