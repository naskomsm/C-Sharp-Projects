namespace HttpServer
{
    public class Constants
    {
        public const string ImageFilePath = "../../../images/cat.png";
        public const string NewLine = "\r\n";

        public class ResponseLines
        {
            public const string Okay = "HTTP/1.0 200 OK";
            public const string NotFound = "HTTP/1.0 404 Not Found";
            public const string Forbidden = "HTTP/1.0 403 Forbidden";
            public const string InternalServer = "HTTP/1.0 500 Internal Server Error";
        }
    }
}
