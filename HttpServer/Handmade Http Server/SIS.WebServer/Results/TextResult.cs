namespace SIS.WebServer.Results
{
    using SIS.HTTP.Common;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Responses;
    using System.Text;

    public class TextResult : HttpResponse
    {
        public TextResult(string content, HttpResponseStatusCode responseStatusCode, string contentType = "text/plain; charset=utf-8")
            : base(responseStatusCode)
        {
            this.Headers.AddHeader(new HttpHeader(HttpHeader.ContentType, contentType));
            this.Content = Encoding.ASCII.GetBytes(content);
        }

        public TextResult(byte[] content, HttpResponseStatusCode responseStatusCode, string contentType = "text/plain; charset=utf-8")
           : base(responseStatusCode)
        {
            this.Headers.AddHeader(new HttpHeader(HttpHeader.ContentType, contentType));
            this.Content = content;
        }
    }
}
