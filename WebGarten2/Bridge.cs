using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebGarten2
{
    public class Bridge : DelegatingHandler
    {
        private readonly FrontHandler _handler;

        public Bridge(FrontHandler handler)
        {
            _handler = handler;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            var tcs = new TaskCompletionSource<HttpResponseMessage>();
            var resp = _handler.Handle(request);
            tcs.SetResult(resp);
            return tcs.Task;
        }
    }
}
