using System.Web.Http.SelfHost;

namespace WebGarten2
{
    public class HttpHost
    {
        private readonly HttpSelfHostServer _server;
        private readonly FrontHandler _handler;

        public HttpHost(string baseAddress)
        {
            var config = new HttpSelfHostConfiguration(baseAddress);
            _handler = new FrontHandler(baseAddress);
            _server = new HttpSelfHostServer(config,new Bridge(_handler));
        }

        public HttpHost Add(params CommandBind[] cmds)
        {
            _handler.Add(cmds);
            return this;
        }

        public void Open()
        {
            _server.OpenAsync().Wait();
        }

        public void Close()
        {
            _server.CloseAsync().Wait();
        }
    }
}