using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Reflection;

namespace WebGarten2
{
    public class FormUrlEncodingParameterBinderProvider : IParameterBinderProvider
    {
        public Func<HttpRequestMessage, object> TryGetBinder(ParameterInfo pi, HttpMethodAttribute attr)
        {
            if (pi.ParameterType == typeof(NameValueCollection))
            {
                return DecodeFormUrlEncoding;
            }
            return null;
        }

        private static NameValueCollection DecodeFormUrlEncoding(HttpRequestMessage req)
        {
            return req.Content.ReadAsFormDataAsync().Result;
        }
    }
}