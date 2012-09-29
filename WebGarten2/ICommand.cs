using System;
using System.Net.Http;

namespace WebGarten2
{
    public interface ICommand
    {
        HttpResponseMessage Execute(HttpRequestMessage req);
    }

    public class CommandBind
    {
        public UriTemplate UriTemplate { get; private set; }
        public HttpMethod HttpMethod { get; private set; }
        public ICommand Command { get; private set; }

        public CommandBind(ICommand cmd, HttpMethod method, UriTemplate template)
        {
            Command = cmd;
            HttpMethod = method;
            UriTemplate = template;
        }
    }
}