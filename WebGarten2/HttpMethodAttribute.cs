using System;
using System.Net.Http;

namespace WebGarten2
{
    public class HttpMethodAttribute : Attribute
    {
        public UriTemplate UriTemplate { get; private set; }
        public HttpMethod HttpMethod { get; private set; }
        public HttpMethodAttribute(string method, string template)
        {
            UriTemplate = new UriTemplate(template);
            HttpMethod = new HttpMethod(method);
        }
    }
}