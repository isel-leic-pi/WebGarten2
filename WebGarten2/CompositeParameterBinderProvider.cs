using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;

namespace WebGarten2
{
    public class CompositeParameterBinderProvider : IParameterBinderProvider
    {
        private readonly ICollection<IParameterBinderProvider> _coll;

        public CompositeParameterBinderProvider(params IParameterBinderProvider[] binders)
        {
            _coll = binders;
        }

        public Func<HttpRequestMessage, object> TryGetBinder(ParameterInfo pi, HttpMethodAttribute attr)
        {
            return _coll.Select(b => b.TryGetBinder(pi, attr)).FirstOrDefault(f => f != null);
        }
    }
}