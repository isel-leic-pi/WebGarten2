using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace WebGarten2
{
    public class FrontHandler : DelegatingHandler
    {
        private readonly string _baseAddress;
        private readonly IDictionary<HttpMethod, UriTemplateTable> _tables = new Dictionary<HttpMethod, UriTemplateTable>();

        public FrontHandler(string baseAddress)
        {
            _baseAddress = baseAddress;
        }

        public void Add(params CommandBind[] binds)
        {
            foreach (var b in binds)
            {
                UriTemplateTable t;
                if (!_tables.TryGetValue(b.HttpMethod, out t))
                {
                    t = new UriTemplateTable(new Uri(_baseAddress));
                    _tables.Add(b.HttpMethod, t);
                }
                t.KeyValuePairs.Add(new KeyValuePair<UriTemplate, object>(b.UriTemplate, b.Command));
            }
        }

        public HttpResponseMessage Handle(HttpRequestMessage req)
        {
            UriTemplateTable t;
            if (!_tables.TryGetValue(req.Method, out t))
            {
                return new HttpResponseMessage(HttpStatusCode.MethodNotAllowed);
            }

            var match = t.MatchSingle(req.RequestUri);
            if (match == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            req.SetUriTemplateMatch(match);
            try
            {
                return (match.Data as ICommand).Execute(req);
            }
            catch(Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
    }
}