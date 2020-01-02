namespace SIS.WebServer
{
    using SIS.WebServer.Routing.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    public class Server
    {
        private const string LocalHostIpAdress = "127.0.0.1";

        private readonly int port;

        private readonly TcpListener listener;

        private readonly IServerRoutingTable serverRoutingTable;

        private bool isRunning;

        public Server(int port, IServerRoutingTable serverRoutingTable)
        {
            this.port = port;
            this.listener = new TcpListener(IPAddress.Parse(LocalHostIpAdress), port);

            this.serverRoutingTable = serverRoutingTable;
        }

        public void Run()
        {
            this.listener.Start();
            this.isRunning = true;

            Console.WriteLine($"Server started at http://{LocalHostIpAdress}:{this.port}");

            while (isRunning)
            {
                Console.WriteLine("Waiting for client...");

                var client = this.listener.AcceptSocket();

                this.Listen(client);
            }
        }

        public void Listen(Socket client)
        {
            var connectionHandler = new ConnectionHandler(client, this.serverRoutingTable);
            connectionHandler.ProcessRequest();
        }
    }
}
