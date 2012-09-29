using System;
using System.Net.Http;
using System.Reflection;

namespace WebGarten2
{
    public class UriTemplateParameterBinderProvider : IParameterBinderProvider
    {
        public Func<HttpRequestMessage, object> TryGetBinder(ParameterInfo pi, HttpMethodAttribute attr)
        {
            if ((pi.ParameterType.IsPrimitive || pi.ParameterType == typeof(String)) && (attr.UriTemplate.PathSegmentVariableNames.Contains(pi.Name.ToUpper()) || attr.UriTemplate.QueryValueVariableNames.Contains(pi.Name.ToUpper())))
            {
                return req => Convert.ChangeType(req.GetUriTemplateMatch().BoundVariables[pi.Name], pi.ParameterType);
            }

            return null;
        }
    }
}