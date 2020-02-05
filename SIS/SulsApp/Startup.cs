namespace SulsApp
{
    using SIS.HTTP;
    using System.Collections.Generic;
    using SIS.MvcFramework.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class Startup : IMvcApplication
    {
        public void ConfigureServices()
        {
            var db = new ApplicationDbContext();
            db.Database.Migrate();
        }

        public void Configure(IList<Route> routeTable)
        {
        }
    }
}
