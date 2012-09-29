using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;

namespace WebGarten2
{
    public class MethodBasedCommand : ICommand
    {
        private readonly MethodInfo _mi;
        private readonly HttpMethodAttribute _attr;
        private readonly Func<HttpRequestMessage, object>[] _binders;

        public MethodBasedCommand(MethodInfo mi, HttpMethodAttribute attr, IEnumerable<Func<HttpRequestMessage, object>> binders)
        {
            _mi = mi;
            _attr = attr;
            _binders = binders.ToArray();
        }

        public CommandBind Bind
        {
            get { return new CommandBind(this, _attr.HttpMethod, _attr.UriTemplate); }
        }

        public HttpResponseMessage Execute(HttpRequestMessage req)
        {
            var o = Activator.CreateInstance(_mi.DeclaringType);
            var prms = new object[_binders.Length];
            for (var i = 0; i < _binders.Length; ++i)
            {
                prms[i] = _binders[i](req);
            }
            try
            {
                return _mi.Invoke(o, prms) as HttpResponseMessage;
            }
            catch (TargetInvocationException e)
            {
                throw e.InnerException;
            }
        }
    }
}