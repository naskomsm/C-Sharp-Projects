namespace SIS.HTTP.Headers
{
    using SIS.HTTP.Common;
    using SIS.HTTP.Headers.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> httpHeeaders;

        public HttpHeaderCollection()
        {
            this.httpHeeaders = new Dictionary<string, HttpHeader>();
        }

        public void AddHeader(HttpHeader header)
        {
            CoreValidator.ThrowIfNull(header, nameof(header));
            this.httpHeeaders.Add(header.Key, header);
        }

        public bool ContainsHeader(string key)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            return this.httpHeeaders.ContainsKey(key);
        }

        public HttpHeader GetHeader(string key)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            return this.httpHeeaders[key];
        }

        public override string ToString()
            => string.Join("\n\r", this
            .httpHeeaders
            .Values
            .Select(h => h.ToString()));
    }
}
