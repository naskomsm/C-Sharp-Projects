namespace Sabv.Data.Tests
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Sabv.Data.Models;

    public class BaseClass
    {
        protected BaseClass()
        {
            this.Configuration = new ConfigurationBuilder()
                .AddJsonFile("mockappsettings.Production.json")
                .Build();
        }

        protected IConfiguration Configuration { get; set; }

        protected UserManager<ApplicationUser> GetUserManager(ApplicationDbContext dbContext)
        {
            var userStore = new UserStore<ApplicationUser>(dbContext);
            return new UserManager<ApplicationUser>(
                userStore, null, null, null, null, null, null, null, null);
        }
    }
}
