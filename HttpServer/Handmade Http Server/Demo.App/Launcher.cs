namespace Demo.App
{
    using SIS.WebServer;
    using SIS.HTTP.Enums;
    using SIS.WebServer.Routing;
    using SIS.WebServer.Routing.Contracts;

    public class Launcher
    {
        public static void Main()
        {
            IServerRoutingTable serverRoutingTable = new ServerRoutingTable();

            serverRoutingTable.Add(HttpRequestMethod.Get, "/", request => new HomeController().Index(request));

            var server = new Server(8000, serverRoutingTable);

            server.Run();
        }
    }
}
