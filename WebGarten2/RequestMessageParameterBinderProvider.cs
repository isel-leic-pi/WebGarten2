using System;
using System.Net.Http;
using System.Reflection;

namespace WebGarten2
{
    public class RequestMessageParameterBinderProvider : IParameterBinderProvider
    {
        public Func<HttpRequestMessage, object> TryGetBinder(ParameterInfo pi, HttpMethodAttribute attr)
        {
            if (pi.ParameterType == typeof(HttpRequestMessage))
            {
                return req => req;
            }
            return null;
        }
    }
}