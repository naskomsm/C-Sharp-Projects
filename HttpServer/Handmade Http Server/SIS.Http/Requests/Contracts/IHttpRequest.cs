namespace SIS.HTTP.Requests.Contracts
{
    using SIS.HTTP.Enums;
    using SIS.HTTP.Headers.Contracts;
    using System.Collections.Generic;

    public interface IHttpRequest
    {
        string Path { get; }

        string Url { get; }

        Dictionary<string, object> FormData { get; }

        Dictionary<string, object> QueryData { get; }
        
        IHttpHeaderCollection Headers { get; }

        HttpRequestMethod Method { get; }
    }
}
