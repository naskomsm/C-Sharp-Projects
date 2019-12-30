namespace Demo.App
{
    using System;
    using System.Text;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Requests;
    using SIS.HTTP.Responses;

    public class Program
    {
        public static void Main()
        {
            string requestString =
                "POST /url/asd?name=john&id=1#fragment HTTP/1.1\r\n"
                + "Authorization: Basic 2131241541\r\n"
                + "Date: " + DateTime.Now + "\r\n"
                + "Host: localhost:5000\r\n"
                + "\r\n"
                + "username=johndoe&password=123";

            HttpRequest request = new HttpRequest(requestString);

            HttpResponse response = new HttpResponse(HttpResponseStatusCode.Ok);

            var firstHeader = new HttpHeader("Date", DateTime.Now.ToShortTimeString());
            var secondHeader = new HttpHeader("Server", "Apache/2.2.14 (Win32)");

            response.AddHeader(firstHeader);
            response.AddHeader(secondHeader);

            var content = "<html><body><h1>Hello, World!</h1></body></html>";
            var contentBytes = Encoding.ASCII.GetBytes(content);

            response.Content = contentBytes;

            Console.WriteLine(response);
        }
    }
}
