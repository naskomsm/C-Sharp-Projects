namespace Demo.App
{
    using System;
    using SIS.HTTP.Requests;

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
        }
    }
}
