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
    using System.Net;
    using System.Web;

    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            requestString.ThrowIfNullOrEmpty(nameof(requestString));

            this.FormData = new Dictionary<string, ISet<string>>();
            this.QueryData = new Dictionary<string, ISet<string>>();
            this.Headers = new HttpHeaderCollection();

            this.ParseRequest(requestString);
        }

        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, ISet<string>> FormData { get; }

        public Dictionary<string, ISet<string>> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }

        public HttpRequestMethod RequestMethod { get; private set; }

        private bool IsValidRequestLine(string[] requestLineParams)
        {
            if (requestLineParams.Length != 3 
                || requestLineParams[2] != GlobalConstants.HttpOneProtocolFragment)
            {
                return false;
            }

            return true;
        }

        private bool HasQueryString()
        {
            return this.Url.Split('?').Length > 1;
        }

        private IEnumerable<string> ParsePlainRequestHeaders(string[] requestLines)
        {
            for (int i = 1; i < requestLines.Length - 1; i++)
            {
                if (!string.IsNullOrEmpty(requestLines[i]))
                {
                    yield return requestLines[i];
                }
            }
        }

        private void ParseRequestMethod(string[] requestLineParams)
        {
            bool parseResult = HttpRequestMethod.TryParse(requestLineParams[0], true,
                out HttpRequestMethod method);

            if (!parseResult)
            {
                throw new BadRequestException(
                    string.Format(GlobalConstants.UnsupportedHttpMethodExceptionMessage,
                        requestLineParams[0]));
            }

            this.RequestMethod = method;
        }

        private void ParseRequestUrl(string[] requestLineParams)
        {
            // if url contains some strange characters this will handle the problem
            this.Url = HttpUtility.UrlDecode(requestLineParams[1]);
        }

        private void ParseRequestPath()
        {
            this.Path = this.Url.Split('?')[0];
        }

        private void ParseRequestHeaders(string[] plainHeaders)
        {
            plainHeaders
                .Select(plainHeader => plainHeader.Split(new[] { ": " }, StringSplitOptions.RemoveEmptyEntries))
                .ToList()
                .ForEach(headerKeyValuePair => this.Headers.AddHeader(new HttpHeader(headerKeyValuePair[0], headerKeyValuePair[1])));
        }

        private void ParseRequestQueryParameters()
        {
            if (this.HasQueryString())
            {
                var parameters = this.Url.Split('?', '#')[1]
                    .Split('&')
                    .Select(plainQueryParameter => plainQueryParameter.Split('='))
                    .ToList();

                foreach (var parameter in parameters)
                {
                    if (!this.QueryData.ContainsKey(parameter[0]))
                    {
                        this.QueryData.Add(parameter[0], new HashSet<string>());
                    }

                    this.QueryData[parameter[0]].Add(WebUtility.UrlDecode(parameter[1]));
                }
            }
        }

        private void ParseRequestFormDataParameters(string requestBody)
        {
            if (string.IsNullOrEmpty(requestBody) == false)
            {
                //TODO: Parse Multiple Parameters By Name
                var paramsPairs = requestBody
                   .Split('&')
                   .Select(plainQueryParameter => plainQueryParameter.Split('='))
                   .ToList();

                foreach (var paramPair in paramsPairs)
                {
                    string key = paramPair[0];
                    string value = paramPair[1];

                    if (this.FormData.ContainsKey(key) == false)
                    {
                        this.FormData.Add(key, new HashSet<string>());
                    }

                    this.FormData[key].Add(WebUtility.UrlDecode(value));
                }
            }
        }

        private void ParseRequestParameters(string requestBody)
        {
            // /home/index?search=nissan&category=SUV
            this.ParseRequestQueryParameters();

            // username=pesho&password=12345
            this.ParseRequestFormDataParameters(requestBody); //TODO: Split
        }

        private void ParseRequest(string requestString)
        {
            // GET /home/index?search=nissan&category=SUV HTTP/1.1
            // Host: localhost:8000
            // Accept: text/plain
            string[] splitRequestString = requestString
                .Split(new[] { GlobalConstants.HttpNewLine }, StringSplitOptions.None);

            // GET /home/index?search=nissan&category=SUV HTTP/1.1
            string[] requestLineParams = splitRequestString[0]
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (!this.IsValidRequestLine(requestLineParams))
            {
                throw new BadRequestException();
            }

            // GET
            this.ParseRequestMethod(requestLineParams);

            // /home/index?search=nissan&category=SUV
            this.ParseRequestUrl(requestLineParams);

            // /home/index
            this.ParseRequestPath();

            // Host: localhost:8000
            // Accept: text/plain
            this.ParseRequestHeaders(this.ParsePlainRequestHeaders(splitRequestString).ToArray());

            // username=pesho&password=12345
            this.ParseRequestParameters(splitRequestString[splitRequestString.Length - 1]);
        }
    }
}
