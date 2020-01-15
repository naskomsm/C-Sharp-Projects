namespace HttpServer
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            // for image
            // Content-Type: image/png
            // and File.Read to read bytes from picture
            // stream.Write()

            string body = "<form method='post'>" +
                            "<input type='text' name='username' placeholder='username'</input>" +
                            "<input type='password' name='password' placeholder='password'</input>" +
                            "<input type='submit'></input>" +
                            "</form>";

            var responseLine = Constants.ResponseLines.Okay;
            var headers = new List<Header>()
            {
                new Header("Content-Type", "text/html"),
                new Header("Server", "MyCustomServer/1.0"),
                new Header("Content-Length:", $"{body.Length}")
            };

            var response = new Response(responseLine, headers, body);

            var port = 8000;
            var ipAdress = IPAddress.Loopback;

            var server = new TcpListener(ipAdress, port);
            server.Start();

            while (true)
            {
                var client = server.AcceptTcpClient();

                using (var stream = client.GetStream())
                {
                    var requestBytes = new byte[100000];
                    var readBytes = stream.Read(requestBytes, 0, requestBytes.Length);
                    var stringRequest = Encoding.UTF8.GetString(requestBytes, 0, readBytes);

                    var splittedRequest = stringRequest.Split(Constants.NewLine);

                    Console.WriteLine("Request string: ");
                    Console.WriteLine(stringRequest);

                    if (splittedRequest[0].Contains("POST"))
                    {
                        Console.WriteLine();
                    }

                    var responseBytes = Encoding.UTF8.GetBytes(response.ToString());
                    stream.Write(responseBytes, 0, responseBytes.Length);
                    
                    Console.WriteLine("Response string: ");
                    Console.WriteLine(response);
                    Console.WriteLine(new string('=', 70));
                }
            }
        }
    }
}
