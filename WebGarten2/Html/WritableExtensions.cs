using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebGarten2.Html
{
    public static class WritableExtensions
    {
        public static HttpContent AsHttpContent(this IWritable w, string mediaType)
        {
            var content = new PushStreamContent((s, c, tc) => Push(w, s));
            content.Headers.ContentType = new MediaTypeHeaderValue(mediaType);
            return content;
        }

        public static HttpContent AsHtmlContent(this IWritable w)
        {
            return w.AsHttpContent("text/html");
        }

        private static void Push(IWritable writable, Stream stream)
        {
            using(var writer = new StreamWriter(stream,Encoding.UTF8))
            {
                writable.WriteTo(writer);
            }
        }
    }
}
