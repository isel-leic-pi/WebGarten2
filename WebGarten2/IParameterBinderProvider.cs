using System;
using System.Net.Http;
using System.Reflection;

namespace WebGarten2
{
    public interface IParameterBinderProvider
    {
        Func<HttpRequestMessage, object> TryGetBinder(ParameterInfo pi, HttpMethodAttribute attr);
    }
}