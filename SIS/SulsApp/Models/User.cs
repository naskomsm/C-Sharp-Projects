namespace SulsApp.Models
{
    using System;
    using SIS.MvcFramework;
    using System.Collections.Generic;

    public class User : IdentityUser<string>
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Submissions = new HashSet<Submission>();
        }

        public virtual ICollection<Submission> Submissions { get; set; }
    }
}
