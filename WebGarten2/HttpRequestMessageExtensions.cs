using System;
using System.Net.Http;

namespace WebGarten2
{
    public static class HttpRequestMessageExtensions
    {
        private static string UriTemplateMatchKey = "UriTemaplateMatch";

        public static UriTemplateMatch GetUriTemplateMatch(this HttpRequestMessage req)
        {
            object item;
            if(req.Properties.TryGetValue(UriTemplateMatchKey,out item))
            {
                return item as UriTemplateMatch;
            }
            return null;
        }
        public static void SetUriTemplateMatch(this HttpRequestMessage req, UriTemplateMatch match)
        {
            req.Properties.Add(UriTemplateMatchKey, match);
        }
    }
}