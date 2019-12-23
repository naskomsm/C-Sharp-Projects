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
            const string ImageFilePath = "../../../images/cat.png";
            const string NewLine = "\r\n";
            const string responseBody = "<form method='post'>" +
                "<input type='text' name='username' placeholder='username'</input>" +
                "<input type='password' name='password' placeholder='password'</input>" +
                "<input type='submit'></input>" +
                "</form>";

            var users = new Dictionary<string, string>();
            var port = 8000;
            var ipAdress = IPAddress.Loopback;

            var server = new TcpListener(ipAdress, port);
            server.Start();

            while (true)
            {
                var client = server.AcceptTcpClient();

                using (var stream = client.GetStream())
                {
                    var requestBytes = new byte[100000]; // just for the test it is 100k
                    var readBytes = stream.Read(requestBytes, 0, requestBytes.Length);
                    var stringRequest = Encoding.UTF8.GetString(requestBytes, 0, readBytes);

                    var splittedRequest = stringRequest.Split(Environment.NewLine);
                    
                    Console.WriteLine(new string('=', 70));
                    Console.WriteLine(stringRequest);

                    if (splittedRequest[0].Contains("POST"))
                    {
                        var nameAndPassword = splittedRequest[splittedRequest.Length - 1].Split("&");
                        var username = nameAndPassword[0].Split("=")[1];
                        var password = nameAndPassword[1].Split("=")[1];

                        Console.WriteLine("Addd user with: ");
                        Console.WriteLine($"Username: {username}");
                        Console.WriteLine($"Password: {password}");

                        if (!users.ContainsKey(username))
                        {
                            users.Add(username, password);
                        }
                    }

                    // text/html response
                    string response = "HTTP/1.0 200 OK" + NewLine +
                                      "Content-Type: text/html" + NewLine +
                                      "Server: MyCustomServer/1.0" + NewLine +
                                      $"Content-Length {responseBody.Length}" + NewLine + NewLine +
                                      responseBody;
                    var responseBytes = Encoding.UTF8.GetBytes(response);
                    stream.Write(responseBytes, 0, responseBytes.Length);

                    // image/png response
                    //string response = "HTTP/1.0 200 OK" + NewLine +
                    //                  "Content-Type: image/png" + NewLine +
                    //                  "Server: MyCustomServer/1.0" + NewLine + NewLine;
                    //var imageBytes = File.ReadAllBytes(ImageFilePath);
                    //stream.Write(imageBytes, 0, imageBytes.Length);
                }
            }
        }
    }
}
