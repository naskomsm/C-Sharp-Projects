namespace SIS.HTTP.Requests
{
    using System;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Common;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Exceptions;
    using SIS.HTTP.Headers.Contracts;
    using System.Collections.Generic;
    using SIS.HTTP.Requests.Contracts;

    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            CoreValidator.ThrowIfNullOrEmpty(requestString, nameof(requestString));

            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeaderCollection();
        }

        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormData { get; }

        public Dictionary<string, object> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }

        public HttpRequestMethod Method { get; }

        private bool IsValidRequestLine(string[] requestLines)
        {
            return true; // todo
        }

        private bool IsValidRequestQueryString(string queryString, string[] queryParams)
        {
            return true; // todo
        }

        private void ParseRequest(string requestString)
        {
            string[] splitRequestConent = requestString.Split(new[] { GlobalConstants.HttpNewLine }, StringSplitOptions.None);
            string[] requestLine = splitRequestConent[0].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (!this.IsValidRequestLine(requestLine))
            {
                throw new BadRequestException();
            }

            // todo
        }
    }
}
