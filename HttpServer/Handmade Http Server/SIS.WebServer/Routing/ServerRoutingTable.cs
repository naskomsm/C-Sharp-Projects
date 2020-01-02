namespace SIS.WebServer.Routing
{
    using System;
    using SIS.HTTP.Enums;
    using System.Collections.Generic;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;
    using SIS.WebServer.Routing.Contracts;

    public class ServerRoutingTable : IServerRoutingTable
    {
        private readonly Dictionary<HttpRequestMethod, Dictionary<string, Func<IHttpRequest, IHttpResponse>>> routes;

        public ServerRoutingTable()
        {
            this.routes = new Dictionary<HttpRequestMethod, Dictionary<string, Func<IHttpRequest, IHttpResponse>>>
            {
                [HttpRequestMethod.Get] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
                [HttpRequestMethod.Post] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
                [HttpRequestMethod.Put] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
                [HttpRequestMethod.Delete] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>()
            };
        }

        public void Add(HttpRequestMethod method, string path, Func<IHttpRequest, IHttpResponse> func)
        {
            this.routes[method].Add(path, func);
        }

        public bool Contains(HttpRequestMethod requestMethod, string path)
        {
            return this.routes[requestMethod].ContainsKey(path);
        }

        public Func<IHttpRequest, IHttpResponse> Get(HttpRequestMethod requestMethod, string path)
        {
            return this.routes[requestMethod][path];
        }
    }
}
