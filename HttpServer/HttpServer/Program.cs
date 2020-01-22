namespace HttpRequester
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class Program
    {
        public static async Task Main()
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 80);
            tcpListener.Start();
            while (true)
            {
                TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                Task.Run(() => ProcessClientAsync(tcpClient));
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            }
        }

        private static async Task ProcessClientAsync(TcpClient tcpClient)
        {
            const string NewLine = "\r\n";
            using NetworkStream networkStream = tcpClient.GetStream();
            byte[] requestBytes = new byte[1000000]; // TODO: Use buffer
            int bytesRead = await networkStream.ReadAsync(requestBytes, 0, requestBytes.Length);
            string request = Encoding.UTF8.GetString(requestBytes, 0, bytesRead);

            string responseText = "<form method='post'>" +
                            "<input type='text' name='username' placeholder='username'</input>" +
                            "<input type='password' name='password' placeholder='password'</input>" +
                            "<input type='submit'></input>" +
                            "</form>";

            string response = "HTTP/1.0 200 OK" + NewLine +
                              "Server: SoftUniServer/1.0" + NewLine +
                              "Content-Type: text/html" + NewLine +
                              "Content-Lenght: " + responseText.Length + NewLine;

            if (request.Contains("POST"))
            {
                var body = request.Split(NewLine + NewLine)[1];
                var username = body.Split("&")[0].Split("=")[1];
                var password = body.Split("&")[1].Split("=")[1];

                response += $"Set-Cookie: {username}={password}; Max-Age: 3600; HttpOnly;" + NewLine +
                              NewLine +
                              responseText;
            }
            else
            {
                response += NewLine + responseText;
            }


            byte[] responseBytes = Encoding.UTF8.GetBytes(response);
            await networkStream.WriteAsync(responseBytes, 0, responseBytes.Length);
            Console.WriteLine(request);
            Console.WriteLine(new string('=', 60));
        }
    }
}