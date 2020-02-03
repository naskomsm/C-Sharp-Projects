namespace SulsApp
{
    using Microsoft.EntityFrameworkCore;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using SulsApp.Controllers;
    using System.Collections.Generic;

    public class Startup : IMvcApplication
    {
        public void ConfigureServices()
        {
        }

        public void Configure(IList<Route> routeTable)
        {
            var db = new ApplicationDbContext();
            db.Database.Migrate();

            routeTable.Add(new Route(HttpMethodType.Get, "/", new HomeController().Index));
            routeTable.Add(new Route(HttpMethodType.Get, "/css/bootstrap.min.css", new StaticFilesController().Bootstrap));
            routeTable.Add(new Route(HttpMethodType.Get, "/css/site.css", new StaticFilesController().Site));
            routeTable.Add(new Route(HttpMethodType.Get, "/css/reset.css", new StaticFilesController().Reset));

            routeTable.Add(new Route(HttpMethodType.Get, "/Users/Login", new UsersController(db).Login));
            routeTable.Add(new Route(HttpMethodType.Post, "/Users/Login", new UsersController(db).DoLogin));

            routeTable.Add(new Route(HttpMethodType.Get, "/Users/Register", new UsersController(db).Register));
            routeTable.Add(new Route(HttpMethodType.Post, "/Users/Register", new UsersController(db).DoRegister));
        }
    }
}
