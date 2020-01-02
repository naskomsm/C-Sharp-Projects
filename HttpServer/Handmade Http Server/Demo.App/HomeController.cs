namespace Demo.App
{
    using SIS.HTTP.Enums;
    using SIS.WebServer.Results;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;

    public class HomeController
    {
        public IHttpResponse Index(IHttpRequest request)
        {
            string content = "<h1>Hello, World!</h1>";

            return new HtmlResult(content, HttpResponseStatusCode.Ok);
        }
    }
}
