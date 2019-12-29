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
    using SIS.HTTP.Extensions;
    using System.Linq;

    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            CoreValidator.ThrowIfNullOrEmpty(requestString, nameof(requestString));

            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeaderCollection();

            ParseRequest(requestString);
        }

        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormData { get; }

        public Dictionary<string, object> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }

        public HttpRequestMethod Method { get; private set; }

        private bool IsValidRequestLine(string[] requestLineParts)
        {
            if (requestLineParts.Length != 3)
            {
                return false;
            }

            var protocol = requestLineParts[2];

            if (protocol != "HTTP/1.1")
            {
                return false;
            }

            return true;
        }

        private void ParseRequestMethod(string[] requestLineParts)
        {
            var method = requestLineParts[0].Capitalize();
            var methodEnum = (HttpRequestMethod)Enum.Parse(typeof(HttpRequestMethod), method, true);
            this.Method = methodEnum;
        }

        private void ParseRequestUrl(string[] requestLineParts)
        {
            var url = requestLineParts[1];
            this.Url = url;
        }

        private void ParseRequestPath()
        {
            var url = this.Url.Split("?");
            var path = url[0];
            this.Path = path;
        }

        private void ParseHeaders(string[] headersParts)
        {
            foreach (var header in headersParts)
            {
                if (string.IsNullOrWhiteSpace(header) || string.IsNullOrEmpty(header) || header == "\r\n")
                {
                    break;
                }

                var splittedHeader = header.Split(": ");

                var headerKey = splittedHeader[0];
                var headerValue = splittedHeader[1];

                if (!this.Headers.ContainsHeader(headerKey))
                {
                    this.Headers.AddHeader(new HttpHeader(headerKey, headerValue));
                }
            }
        }

        private void ParseQueryParameters()
        {
            // TODO: parse multiple parameters ( cars=Volvo&cars=BMW&cars=Opel ) , select many HTML ( hint )
            var url = this.Url.Split('?', '#');
            var pairs = url[1].Split("&");

            if (pairs.Length > 1)
            {
                foreach (var queryString in pairs)
                {
                    var queryStringSplited = queryString.Split("=");

                    var key = queryStringSplited[0]; // name
                    var value = queryStringSplited[1]; // gosho

                    if (!this.QueryData.ContainsKey(key))
                    {
                        this.QueryData.Add(key, value);
                    }
                }
            }
        }

        private bool IsValidRequestQueryString(string queryString, string[] queryParams)
        {
            if (string.IsNullOrEmpty(queryString) || string.IsNullOrWhiteSpace(queryString) || queryParams.Length < 1)
            {
                return false;
            }

            return true;
        }

        private void ParseRequestParameters(string formData)
        {
            ParseQueryParameters();
            ParseFormDataParameters(formData);
        }

        private void ParseFormDataParameters(string formData)
        {
            var pairs = formData.Split("&");
            if (pairs.Length > 1)
            {
                foreach (var queryString in pairs)
                {
                    var queryStringSplited = queryString.Split("=");

                    var key = queryStringSplited[0]; // name
                    var value = queryStringSplited[1]; // gosho

                    if (!this.FormData.ContainsKey(key))
                    {
                        this.FormData.Add(key, value);
                    }
                }
            }
        }

        private void ParseRequest(string requestString)
        {
            var splitRequestContent = requestString.Split(new[] { GlobalConstants.HttpNewLine }, StringSplitOptions.None);

            var requestLine = splitRequestContent[0].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); // GET /home/index?name=gosho&name2=stoqn HTTP/1.1
            var headersLines = splitRequestContent.Skip(1).ToArray();

            if (!this.IsValidRequestLine(requestLine))
            {
                throw new BadRequestException();
            }


            ParseRequestMethod(requestLine);
            ParseRequestUrl(requestLine);
            ParseRequestPath();

            var queryString = this.Url.Split("?")[1];
            var queryParams = queryString.Split("&");

            if (!this.IsValidRequestQueryString(queryString, queryParams))
            {
                throw new BadRequestException();
            }

            ParseHeaders(headersLines);

            var formData = splitRequestContent[splitRequestContent.Length - 1];
            ParseRequestParameters(formData);
        }
    }
}
