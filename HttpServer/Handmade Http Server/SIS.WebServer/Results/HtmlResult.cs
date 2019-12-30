namespace SIS.WebServer.Results
{
    using SIS.HTTP.Common;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Responses;
    using System.Text;

    public class HtmlResult : HttpResponse
    {
        public HtmlResult(string content, HttpResponseStatusCode responseStatusCode)
            : base(responseStatusCode)
        {
            this.Headers.AddHeader(new HttpHeader(HttpHeader.ContentType, "text/html; charset=utf-8"));
            this.Content = Encoding.ASCII.GetBytes(content);
        }
    }
}
