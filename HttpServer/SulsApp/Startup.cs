namespace SulsApp
{
    using SIS.HTTP;
    using SIS.MvcFramework;
    using Suls.Data;
    using Suls.Services.Implementations;
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
            db.Database.EnsureCreated();

            var usersService = new UsersService(db);
            routeTable.Add(new Route(HttpMethodType.Get, "/", new HomeController().Index));
            routeTable.Add(new Route(HttpMethodType.Get, "/css/bootstrap.min.css", new StaticFilesController().Bootstrap));
            routeTable.Add(new Route(HttpMethodType.Get, "/css/site.css", new StaticFilesController().Site));
            routeTable.Add(new Route(HttpMethodType.Get, "/css/reset.css", new StaticFilesController().Reset));
            routeTable.Add(new Route(HttpMethodType.Get, "/Users/Login", new UsersController(usersService).Login));
            routeTable.Add(new Route(HttpMethodType.Post, "/Users/Login", new UsersController(usersService).DoLogin));
            routeTable.Add(new Route(HttpMethodType.Get, "/Users/Register", new UsersController(usersService).Register));
            routeTable.Add(new Route(HttpMethodType.Post, "/Users/Register", new UsersController(usersService).DoRegister));
        }
    }
}
